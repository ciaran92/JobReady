using Amazon.S3;
using Amazon.S3.Model;
using Monolith.Domain.Interfaces;
using Monolith.Domain.Models.Bucket;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Monolith.Core.Repositories
{
    public class AmazonS3BucketRepository : IAmazonS3BucketRepository
    {
        private readonly IAmazonS3 _s3Client;

        public AmazonS3BucketRepository(IAmazonS3 s3Client)
        {
            _s3Client = s3Client;
        }

        public async Task<bool> DoesS3BucketExist(string bucketName)
        {
            return await _s3Client.DoesS3BucketExistAsync(bucketName);
        }

        public async Task<CreateBucketResponse> CreateBucketAsync(string bucketName)
        {
            var putBucketRequest = new PutBucketRequest
            {
                BucketName = bucketName,
                UseClientRegion = true
            };

            var response = await _s3Client.PutBucketAsync(putBucketRequest);

            return new CreateBucketResponse
            {
                BucketName = bucketName,
                RequestId = response.ResponseMetadata.RequestId
            };
        }

        public async Task<IEnumerable<ListS3BucketsResponse>> ListBucketsAsync()
        {
            var response = await _s3Client.ListBucketsAsync();

            return response.Buckets.Select(b => new ListS3BucketsResponse
            {
                BucketName = b.BucketName,
                CreationDate = b.CreationDate
            });
        }
    }
}
