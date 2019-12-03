using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Monolith.Domain.Interfaces;
using Monolith.Domain.Models.Topic;

namespace Monolith.Controllers
{
    [Route("api/topic")]
    [ApiController]
    public class TopicController : ControllerBase
    {
        private readonly ITopicService _topicService;
        private readonly ICourseService _courseService;
        
        public TopicController(ITopicService topicService, ICourseService courseService)
        {
            _topicService = topicService;
            _courseService = courseService;
        }

        [HttpGet]
        public IActionResult GetTopics(int courseId)
        {
            var topics = _courseService.GetTopics(courseId);

            if (topics == null)
            {
                return BadRequest();
            }
            
            return Ok(topics);
        }
        
        [HttpPost]
        public IActionResult CreateTopic(int courseId, [FromBody] List<CreateTopicModel> request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var response = _topicService.CreateTopic(courseId, request);
            return response? (IActionResult) Ok() : BadRequest();
        }

        [HttpPut]
        public IActionResult UpdateTopic()
        {

            return null;
        }
    }
}