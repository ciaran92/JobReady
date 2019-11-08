using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Monolith.Core.Services;
using Monolith.Domain.Interfaces;
using Monolith.Domain.Models.Lecture;

namespace Monolith.Controllers
{
    [Route("api/lecture")]
    [ApiController]
    public class LectureController : ControllerBase
    {
        private readonly ILectureService _lectureService;
        
        public LectureController(ILectureService lectureService)
        {
            _lectureService = lectureService;
        }
        
        [HttpPost]
        public IActionResult CreateTopic(int topicId, [FromBody] List<CreateLectureModel> request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var response = _lectureService.CreateLecture(topicId, request);
            return response? (IActionResult) Ok() : BadRequest();
        }
    }
}