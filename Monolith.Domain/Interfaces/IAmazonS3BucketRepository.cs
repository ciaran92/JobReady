using Monolith.Domain.Models.Bucket;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Monolith.Domain.Interfaces
{
    public interface IAmazonS3BucketRepository
    {
        Task<bool> DoesS3BucketExist(string bucketName);
        Task<CreateBucketResponse> CreateBucketAsync(string bucketName);
        Task<IEnumerable<ListS3BucketsResponse>> ListBucketsAsync();
    }
}
