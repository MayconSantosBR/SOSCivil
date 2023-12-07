using Amazon.S3;
using Amazon.S3.Model;
using FluentResults;
using SosCivil.Api.Services.Interfaces;
using SosCivil.Core.Data.Enums;
using SosCivil.Core.Extensions;

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

        public async Task<Result<PutObjectResponse>> UploadFileAsync(string folder, Stream file, string contentType)
        {
            var key = $"{folder}/{Guid.NewGuid()}.jpg";

            var request = new PutObjectRequest
            {
                BucketName = _configuration.GetValue<string>("ConnectionStrings:Amazon:BucketName"),
                Key = key,
                InputStream = file,
                ContentType = contentType
            };

            return Result.Ok(await _amazonS3.PutObjectAsync(request));
        }
    }
}
