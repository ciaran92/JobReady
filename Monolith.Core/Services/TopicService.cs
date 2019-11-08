using System;
using System.Collections.Generic;
using System.Linq;
using Monolith.Core.Repositories;
using Monolith.Domain.BusinessObjects;
using Monolith.Domain.Context;
using Monolith.Domain.Interfaces;
using Monolith.Domain.Models.Topic;

namespace Monolith.Core.Services
{
    public class TopicService : ITopicService
    {
        private readonly PrimarydbContext _context;
        private readonly ITopicRepository _topicRepository;
        
        public TopicService(PrimarydbContext context)
        {
            _context = context;
            _topicRepository = new TopicRepository(context);
        }
        
        public bool CreateTopic(int courseId, List<CreateTopicModel> topicsForCreation)
        {
            var course = _context.Course.Any(x => x.CourseId == courseId);

            if (course)
            {
                var topics = new List<Topic>();

                foreach (var newTopic in topicsForCreation)
                {
                    var topic = new Topic
                    {
                        Topicname = newTopic.Topicname,
                        Courseid = courseId
                    };

                    _topicRepository.Add(topic);
                    topics.Add(topic);
                }

                return _topicRepository.Save();
            }

            return false;
        }
    }
}