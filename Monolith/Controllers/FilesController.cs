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
        private readonly IFilesRepository _filesRepository;
        
        public FilesController(IFilesRepository filesRepository)
        {
            _filesRepository = filesRepository;
        }

        [HttpPost]
        [Route("upload")]
        public async Task<ActionResult<UploadFileResponse>> UploadFiles(IList<IFormFile> formFiles)
        {
            if (formFiles == null)
            {
                return BadRequest("The request doesn't contain any files to be uploaded.");
            }

            string bucketName = "jrthumbnails";
            var response = await _filesRepository.UploadFiles(bucketName, formFiles);

            if (response == null)
            {
                return BadRequest();
            }

            return Ok(response);
        }
        
    }
}