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
            return new Course
            {
                CourseName = model.CourseName,
                CourseDescription = model.CourseDescription,
                InstructorId = model.InstructorId
            };
        }
    }
}