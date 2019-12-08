using System;
using System.Collections.Generic;
using System.Linq;
using Monolith.Core.Repositories;
using Monolith.Domain.BusinessObjects;
using Monolith.Domain.Context;
using Monolith.Domain.Interfaces;
using Monolith.Domain.Mappers;
using Monolith.Domain.Models.Topic;

namespace Monolith.Core.Services
{
    public class TopicService : ITopicService
    {
        private readonly PrimarydbContext _context;
        private readonly ITopicRepository _topicRepository;
        private readonly ICourseRepository _courseRepository;
        
        public TopicService(PrimarydbContext context, ITopicRepository topicRepository)
        {
            _context = context;
            _topicRepository = topicRepository;
            _courseRepository = new CourseRepository(_context);
        }
        
        public IEnumerable<TopicDto> GetTopicsForCourse(int courseId)
        {
            // check the course exists
            if (!_courseRepository.CourseExists(courseId))
            {
                return null;
            }
            
            var topics = _topicRepository.GetTopicsForCourse(courseId);

            if (topics == null)
            {
                return null;
            }

            // Map to topic response model
            return topics.Select(topic => TopicToTopicDto.Map(topic)).ToList();
        }
        
        public bool CreateTopic(int courseId, CreateTopicRequest request)
        {
            var course = _context.Course.Any(x => x.CourseId == courseId);

            if (course)
            {
                var topic = new Topic
                {
                    CourseId = courseId,
                    TopicName = request.TopicName,
                    TopicDescription = request.TopicDescription,
                    TopicOrder = request.TopicOrder,
                    CreatedOn = DateTime.Now
                };

                _topicRepository.Add(topic);
                return _topicRepository.Save();
            }

            return false;
        }
    }
}