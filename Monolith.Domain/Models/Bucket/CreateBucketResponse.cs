using System;
using System.Collections.Generic;
using System.Text;

namespace Monolith.Domain.Models.Bucket
{
    public class CreateBucketResponse
    {
        public string RequestId { get; set; }
        public string BucketName { get; set; }
    }
}
