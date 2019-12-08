using System.Collections;
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
        
        public TopicController(ITopicService topicService)
        {
            _topicService = topicService;
        }

        [HttpGet]
        [Route("{courseId}")]
        public ActionResult<IEnumerable<TopicDto>> GetTopics(int courseId)
        {
            var topics = _topicService.GetTopicsForCourse(courseId);

            if (topics == null)
            {
                return BadRequest();
            }
            
            return Ok(topics);
        }
        
        [HttpPost]
        [Route("new/{courseId}")]
        public ActionResult<IEnumerable<TopicDto>> CreateTopic(int courseId, [FromBody] CreateTopicRequest request)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest();
            }

            var response = _topicService.CreateTopic(courseId, request);

            if (!response) return BadRequest();
            
            var topics = _topicService.GetTopicsForCourse(courseId);
            return Ok(topics);
        }

        [HttpPut]
        public IActionResult UpdateTopic()
        {
            return null;
        }
    }
}