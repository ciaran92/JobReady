using Microsoft.AspNetCore.Mvc;
using Monolith.Domain.Interfaces;
using Monolith.Domain.Mappers;
using Monolith.Domain.Models.Course;

namespace Monolith.Controllers
{
    [Route("api/course")]
    [ApiController]
    public class CourseController : ControllerBase
    {

        private readonly ICourseService _courseService;
        
        public CourseController(ICourseService courseService)
        {
            _courseService = courseService;
        }
        
        [HttpPost("CreateCourse")]
        public IActionResult CreateCourse([FromBody] CreateCourseModel model)
        {
            if (!ModelState.IsValid)
            {
                return ValidationProblem(ModelState);
            }

            var response = _courseService.CreateCourse(CreateCourseModelToCourseMapper.Map(model));

            if (!response.Success)
            {
                return BadRequest();
            }

            return Ok(response);
        }
    }
}