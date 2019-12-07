using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Monolith.Domain.Models.Files;

namespace Monolith.Domain.Interfaces
{
    public interface IFilesRepository
    {
        Task<UploadFileResponse> UploadFiles(string bucketName, IList<IFormFile> files);
    }
}