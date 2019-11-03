using System.Collections.Generic;
using System.Collections.ObjectModel;
using Monolith.Domain.BusinessObjects;
using Monolith.Domain.Models.Course;

namespace Monolith.Domain.Mappers
{
    public static class CreateCourseModelToCourseMapper
    {

        public static Course Map(CreateCourseModel model)
        {
            var newTopics = new Collection<Topic>();

            foreach (var topic in model.Topic)
            {
                newTopics.Add(new Topic
                {
                    Topicname = topic.Topicname
                });
            }
            
            return new Course
            {
                CourseName = model.CourseName,
                CourseDescription = model.CourseDescription,
                InstructorId = model.InstructorId,
                Topic = newTopics
            };
        }
    }
}