using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Monolith.Domain.Interfaces;
using Monolith.Domain.Models.Files;

namespace Monolith.Controllers
{
    [Route("api/files")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        // TODO: move these bucket names to appSettings file
        private const string ThumbnailImageBucket = "jrthumbnails";
        private readonly IFilesRepository _filesRepository;
        
        public FilesController(IFilesRepository filesRepository)
        {
            _filesRepository = filesRepository;
        }

        [HttpPost]
        [Route("upload/{courseId}")]
        public async Task<ActionResult<UploadFileResponse>> UploadThumbnailImage(IFormFile file, int courseId)
        {
            if (file == null)
            {
                return BadRequest("The request doesn't contain any files to be uploaded.");
            }
            
            var response = await _filesRepository.UploadFiles(ThumbnailImageBucket, file);

            if (response == null)
            {
                return BadRequest();
            }

            return Ok();
        }
        
    }
}