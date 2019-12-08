using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Transfer;
using Microsoft.AspNetCore.Http;
using Monolith.Domain.Interfaces;
using Monolith.Domain.Models.Files;

namespace Monolith.Core.Repositories
{
    public class FilesRepository : IFilesRepository
    {
        private readonly IAmazonS3 _s3Client;

        public FilesRepository(IAmazonS3 s3Client)
        {
            _s3Client = s3Client;
        }

        public async Task<UploadFileResponse> UploadFiles(string bucketName, IFormFile file)
        {
            var response = new List<string>();

            string name = file.FileName;
            string newFileName;
            var date = DateTime.Now;
            newFileName = date + "_100236";
            var uploadRequest = new TransferUtilityUploadRequest
            {
                InputStream = file.OpenReadStream(),
                Key = newFileName,
                BucketName = bucketName,
                CannedACL = S3CannedACL.NoACL
            };

            using (var fileTransferUtility = new TransferUtility(_s3Client))
            {
                await fileTransferUtility.UploadAsync(uploadRequest);
            }

            var expiryUrlRequest = new GetPreSignedUrlRequest
            {
                BucketName = bucketName,
                Key = file.FileName,
                Expires = DateTime.Now.AddMinutes(5)
            };

                var url = _s3Client.GetPreSignedURL(expiryUrlRequest);

            return new UploadFileResponse
            {
                Success = true
            };
        }
    }
}