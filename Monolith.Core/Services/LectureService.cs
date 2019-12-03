using System.Collections.Generic;
using System.Linq;
using Monolith.Core.Repositories;
using Monolith.Core.Repositories.Generic;
using Monolith.Domain.BusinessObjects;
using Monolith.Domain.Context;
using Monolith.Domain.Interfaces;
using Monolith.Domain.Models.Lecture;

namespace Monolith.Core.Services
{
    public class LectureService : ILectureService
    {
        private readonly PrimarydbContext _context;
        private readonly ITopicRepository _topicRepository;
        private readonly ILectureRepository _lectureRepository;
        //private readonly ICourseRepository _courseRepository;
        
        public LectureService(PrimarydbContext context, ILectureRepository lectureRepository, ITopicRepository topicRepository)
        {
            _context = context;
            _lectureRepository = lectureRepository;
            _topicRepository = topicRepository;
        }
        
        public bool CreateLecture(int topicId, List<CreateLectureModel> lectureModel)
        {
            if (_topicRepository.TopicExists(topicId))
            {
                var lectures = new List<Lecture>();

                foreach (var model in lectureModel)
                {
                    var lecture = new Lecture
                    {
                        Lecturename = model.Lecturename,
                        Topicid = topicId
                    };

                    _lectureRepository.Add(lecture);
                    lectures.Add(lecture);
                }

                return _lectureRepository.Save();
            }

            return false;
        }
    }
}