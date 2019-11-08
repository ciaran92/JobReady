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
        private readonly IRepositoryBase<Lecture> _lectureRepository;
        
        public LectureService(PrimarydbContext context)
        {
            _context = context;
            _lectureRepository = new LectureRepository(context);
        }
        
        public bool CreateLecture(int topicId, List<CreateLectureModel> lecturesForCreation)
        {
            var topic = _context.Topic.Any(x => x.Topicid == topicId);

            if (topic)
            {
                var lectures = new List<Lecture>();

                foreach (var l in lecturesForCreation)
                {
                    var lecture = new Lecture
                    {
                        Lecturename = l.Lecturename,
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