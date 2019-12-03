using System.Collections.Generic;
using Monolith.Core.Repositories.Generic;
using Monolith.Domain.BusinessObjects;

namespace Monolith.Core.Repositories
{
    public interface ICourseRepository : IRepositoryBase<Course>
    {
        bool CourseExists(int courseId);
        List<Course> GetAllCourses(int userId);
    }
}