using System;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Monolith.Domain.Interfaces;
using Monolith.Domain.Mappers;
using Monolith.Domain.Models.Course;
using Monolith.Helpers;

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
        
        [Authorize]
        [HttpPost("create-course")]
        public IActionResult CreateCourse([FromBody] CreateCourseModel model)
        {
            if (!ModelState.IsValid)
            {
                return ValidationProblem(ModelState);
            }
            
            var claimsIdentity = User.Identity as ClaimsIdentity;
            var userId = claimsIdentity.FindFirst(ClaimTypes.Email)?.Value;

            var response = _courseService.CreateCourse(CreateCourseModelToCourseMapper.Map(model));

            if (!response.Success)
            {
                return BadRequest();
            }

            return Ok(response);
        }

        [HttpPut]
        public IActionResult UpdateCourse(int userId, int courseId, [FromBody] UpdateCourseRequest changes)
        {
            if (changes == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return new UnprocessableEntity(ModelState);
            }

            var course = _courseService.GetCourse(userId, courseId);
            
            if (course == null)
            {
                return NotFound();
            }

            if (!_courseService.UpdateCourse(course, changes))
            {
                throw new Exception($"Update on Course {courseId} for user {userId} failed to Save Changes");
            }

            return NoContent();
        }
    }
}