﻿using System;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Monolith.Domain.BusinessObjects;
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

        [HttpGet("InstructorDashboard/{id}")]
        public IActionResult GetInstructorDashboard(int id)
        {
            var courses = _courseService.GetOwnedCourses(id);

            return Ok(courses);
        }

        [HttpGet("GetCourseDetails/{id}")]
        public IActionResult GetCourseDetails(int id)
        {
            var details = _courseService.GetCourseDetails(id);
            
            if (details == null)
            {
                return BadRequest("Course not found");
            }
            
            return Ok(details);
        }
        
        //[Authorize]
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

        [HttpPatch("{courseId}")]
        public IActionResult PartiallyUpdateCourse(int courseId, [FromBody] JsonPatchDocument<CourseForUpdateDto> patchDocument)
        {
            if (patchDocument == null)
            {
                return BadRequest();
            }

            // TODO: Get the userId from the bearer token claims
            var course = _courseService.GetCourseForInstructor(7, courseId);

            var courseToPatch = new CourseForUpdateDto()
            {
                CourseName = course.CourseName,
                CourseDescription = course.CourseDescription
            };
            
            patchDocument.ApplyTo(courseToPatch);

            _courseService.UpdateCourse(course, courseToPatch);

            return NoContent();
        }

        [HttpPut]
        public IActionResult UpdateCourse(int userId, int courseId, [FromBody] CourseForUpdateDto changes)
        {
            /*if (changes == null)
            {
                return BadRequest();
            }

            if (!ModelState.IsValid)
            {
                return new UnprocessableEntity(ModelState);
            }

            var course = _courseService.GetCourseDetails(courseId);
            
            if (course == null)
            {
                return NotFound();
            }

            if (!_courseService.UpdateCourse(course, changes))
            {
                throw new Exception($"Update on Course {courseId} for user {userId} failed to Save Changes");
            }*/

            return NoContent();
        }
    }
}