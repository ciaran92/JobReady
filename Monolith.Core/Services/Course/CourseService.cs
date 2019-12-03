using System.Collections.Generic;
using System.Linq;
using Monolith.Core.Repositories;
using Monolith.Domain.BusinessObjects;
using Monolith.Domain.Context;
using Monolith.Domain.Interfaces;
using Monolith.Domain.Mappers;
using Monolith.Domain.Models.Course;
using Monolith.Domain.Models.Topic;

namespace Monolith.Core.Services.Course
{
    public class CourseService : ICourseService
    {
        private readonly PrimarydbContext _context;
        private readonly ICourseRepository _courseRepository;
        private readonly ITopicRepository _topicRepository;
        
        public CourseService(PrimarydbContext context, ITopicRepository topicRepository)
        {
            _context = context;
            _topicRepository = topicRepository;
            _courseRepository = new CourseRepository(_context);
        }

        public List<CourseListViewModel> GetOwnedCourses(int userId)
        {
            var request = _courseRepository.GetAllCourses(userId);

            var courses = new List<CourseListViewModel>();

            foreach (var course in request)
            {
                courses.Add(new CourseListViewModel()
                {
                    CourseId = course.CourseId,
                    CourseName = course.CourseName
                });
            }

            return courses;
        }

        public List<TopicDto> GetTopics(int courseId)
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
            
            var topicDtos = new List<TopicDto>();
            
            // Map to topic response model
            foreach (var topic in topics)
            {
                topicDtos.Add(TopicToTopicDto.Map(topic));
            }
            
            return topicDtos;
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
                CourseViewModel = new CourseDetailsViewModel
                {
                    CourseId = req.CourseId,
                    CourseName = req.CourseName,
                    CourseDescription = req.CourseDescription
                }
            };
        }

        public CourseDetailsViewModel GetCourseDetails(int courseId)
        {
            var course = _context.Course.FirstOrDefault(x => x.CourseId == courseId);

            if (course != null)
            {
                return new CourseDetailsViewModel()
                {
                    CourseId = courseId,
                    CourseName = course.CourseName,
                    CourseDescription = course.CourseDescription
                };
            }
            
            return null;
        }
        
        public Domain.BusinessObjects.Course GetCourse(int courseId)
        {
            var course = _context.Course.FirstOrDefault(x => x.CourseId == courseId);
            return course ?? null;
        }

        public bool UpdateCourse(Domain.BusinessObjects.Course course, UpdateCourseRequest changes)
        {
            UpdateCourseToCourseMapper.Map(course, changes);

            return _courseRepository.Save();
        }
    }
}