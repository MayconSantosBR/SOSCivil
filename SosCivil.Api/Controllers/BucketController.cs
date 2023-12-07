using FluentResults;
using Microsoft.AspNetCore.Mvc;
using SosCivil.Api.Controllers.Base;
using SosCivil.Api.Services.Interfaces;

namespace SosCivil.Api.Controllers
{
    [ApiController]
    [Route("api/")]
    public class BucketController : SosCivilControllerBase
    {
        private readonly IBucketService _bucketService;

        public BucketController(IBucketService bucketService)
        {
            _bucketService = bucketService;
        }

        [Route("bucket/{folder}")]
        [HttpPost]
        public async Task<ActionResult> UploadFile(string folder, IFormFile file)
        {
            try
            {
                return ValidateServiceResponse(await _bucketService.UploadFileAsync(folder, file));
            }
            catch (Exception e)
            {
                return BadRequest(Result.Fail(e.Message));
            }
        }
    }
}
