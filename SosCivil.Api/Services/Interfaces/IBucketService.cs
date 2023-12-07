using Amazon.S3.Model;
using FluentResults;
using SosCivil.Core.Data.Enums;

namespace SosCivil.Api.Services.Interfaces
{
    public interface IBucketService
    {
        Task<Result<object>> UploadFileAsync(string folder, IFormFile file);
    }
}