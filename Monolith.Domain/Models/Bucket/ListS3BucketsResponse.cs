using System;
using System.Collections.Generic;
using System.Text;

namespace Monolith.Domain.Models.Bucket
{
    public class ListS3BucketsResponse
    {
        public string BucketName { get; set; }
        public DateTime CreationDate { get; set; }
    }
}
