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