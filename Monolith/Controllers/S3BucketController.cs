using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Monolith.Domain.Interfaces;
using Monolith.Domain.Models.Bucket;

namespace Monolith.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class S3BucketController : ControllerBase
    {
        private readonly IAmazonS3BucketRepository _bucketRepository;

        public S3BucketController(IAmazonS3BucketRepository bucketRepository)
        {
            _bucketRepository = bucketRepository;
        }

        [HttpPost]
        [Route("create/{bucketName}")]
        public async Task<ActionResult<CreateBucketResponse>> CreateS3Bucket([FromRoute] string bucketName)
        {
            var bucketExists = await _bucketRepository.DoesS3BucketExist(bucketName);

            if (bucketExists)
            {
                return BadRequest("S3 Bucket Already Exists");
            }

            var result = await _bucketRepository.CreateBucketAsync(bucketName);

            if(result == null)
            {
                return BadRequest();
            }

            return Ok(result);
        }

        [HttpGet]
        [Route("list")]
        public async Task<ActionResult<IEnumerable<ListS3BucketsResponse>>> ListS3Buckets()
        {
            var result = await _bucketRepository.ListBucketsAsync();

            if(result == null)
            {
                return NotFound();
            }

            return Ok(result);
        }
    }

    
}