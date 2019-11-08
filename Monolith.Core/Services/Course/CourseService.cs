using System.Linq;
using Monolith.Core.Repositories;
using Monolith.Domain.Context;
using Monolith.Domain.Interfaces;
using Monolith.Domain.Mappers;
using Monolith.Domain.Models.Course;

namespace Monolith.Core.Services.Course
{
    public class CourseService : ICourseService
    {
        private readonly PrimarydbContext _context;
        private readonly CourseRepository _courseRepository;
        
        public CourseService(PrimarydbContext context)
        {
            _context = context;
            _courseRepository = new CourseRepository(_context);
        }

        public CreateCourseResponse CreateCourse(Domain.BusinessObjects.Course req)
        {
            
            // check course name not taken / course doesn't exist
            var courseNameTaken = _context.Course.Any(x => x.CourseName == req.CourseName);
            
            // map to course object
            if (courseNameTaken)
            {
                return new CreateCourseResponse
                {
                    Success = false
                };
            }
                
            // Create the course & save to db
            _courseRepository.Add(req);
            _courseRepository.Save();
                
            // Return view model
            return new CreateCourseResponse
            {
                Success = true,
                CourseViewModel = new CourseViewModel
                {
                    CourseId = req.CourseId,
                    CourseName = req.CourseName,
                    CourseDescription = req.CourseDescription
                }
            };
        }

        public Domain.BusinessObjects.Course GetCourse(int userId, int courseId)
        {
            var course = _context.Course
                .Where(x => x.CourseId == courseId)
                .FirstOrDefault(x => x.InstructorId == userId);
            
            return course;
        }

        public bool UpdateCourse(Domain.BusinessObjects.Course course, UpdateCourseRequest changes)
        {
            UpdateCourseToCourseMapper.Map(course, changes);

            return _courseRepository.Save();
        }
    }
}