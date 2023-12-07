using Amazon.S3;
using Amazon.S3.Model;
using FluentResults;
using SosCivil.Api.Services.Interfaces;
using SosCivil.Core.Data.Enums;
using SosCivil.Core.Extensions;
using System.Net.Http.Headers;

namespace SosCivil.Api.Services
{
    public class BucketService : IBucketService
    {
        private readonly IConfiguration _configuration;
        private readonly IAmazonS3 _amazonS3;

        public BucketService(IConfiguration configuration, IAmazonS3 amazonS3)
        {
            _configuration = configuration;
            _amazonS3 = amazonS3;
        }

        public async Task<Result<object>> UploadFileAsync(string folder, IFormFile file)
        {
            var extension = GetFileExtension(file) ?? throw new Exception("File extension wasn't identified");

            var key = $"{folder}/{Guid.NewGuid()}.{extension}";

            var request = new PutObjectRequest
            {
                BucketName = _configuration.GetValue<string>("Amazon:BucketName"),
                Key = key,
                InputStream = file.OpenReadStream(),
                ContentType = file.ContentType,
            };

            await _amazonS3.PutObjectAsync(request);

            return Result.Ok<object>(new { url = $"{_configuration.GetValue<string>("Amazon:Url")}{key}" });
        }

        private string? GetFileExtension(IFormFile file)
        {
            if (file == null)
                return null;

            var fileName = file.FileName;
            var contentDisposition = ContentDispositionHeaderValue.Parse(file.ContentDisposition);

            if (contentDisposition.DispositionType.Equals("attachment", StringComparison.OrdinalIgnoreCase))
            {
                var fileExtension = Path.GetExtension(fileName);
                return fileExtension;
            }else
            {
                return fileName.LastIndexOf('.') > 0 ? fileName.Substring(fileName.LastIndexOf('.') + 1) : null;
            }
        }
    }
}
