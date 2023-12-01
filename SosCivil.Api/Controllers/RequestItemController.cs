using FluentResults;
using Microsoft.AspNetCore.Mvc;
using SosCivil.Api.Controllers.Base;
using SosCivil.Api.Services.Interfaces;

namespace SosCivil.Api.Controllers
{
    [ApiController]
    [Route("api/")]
    public class RequestItemController : SosCivilControllerBase
    {
        private readonly IRequestItemService _requestItemService;

        public RequestItemController(IRequestItemService requestItemService)
        {
            _requestItemService = requestItemService;
        }

        [Route("request-items")]
        [HttpGet]
        public async Task<ActionResult> All()
        {
            try
            {
                return ValidateServiceResponse(await _requestItemService.GetAllAsync());
            }
            catch (Exception e)
            {
                return BadRequest(Result.Fail(e.Message));
            }
        }

        [Route("request-items/{id}")]
        [HttpGet]
        public async Task<ActionResult> Get(long id)
        {
            try
            {
                return ValidateServiceResponse(await _requestItemService.GetByIdAsync(id));
            }
            catch (Exception e)
            {
                return BadRequest(Result.Fail(e.Message));
            }
        }
    }
}
