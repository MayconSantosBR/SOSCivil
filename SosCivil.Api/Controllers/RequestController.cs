using FluentResults;
using Microsoft.AspNetCore.Mvc;
using SosCivil.Api.Controllers.Base;
using SosCivil.Api.Models.Dtos.Controllers;
using SosCivil.Api.Services.Interfaces;

namespace SosCivil.Api.Controllers
{
    [ApiController]
    [Route("api/")]
    public class RequestController : SosCivilControllerBase
    {
        private readonly IRequestService _requestService;

        public RequestController(IRequestService requestService)
        {
            _requestService = requestService;
        }

        [Route("requests")]
        [HttpGet]
        public async Task<ActionResult> All()
        {
            try
            {
                return ValidateServiceResponse(await _requestService.GetAllAsync());
            }
            catch (Exception e)
            {
                return BadRequest(Result.Fail(e.Message));
            }
        }

        [Route("requests")]
        [HttpPost]
        public async Task<ActionResult> Create([FromBody] RequestDto requestDto)
        {
            try
            {
                return ValidateServiceResponse(await _requestService.MapAndCreateAsync(requestDto));
            }
            catch (Exception e)
            {
                return BadRequest(Result.Fail(e.Message));
            }
        }

        [Route("requests/{id}")]
        [HttpGet]
        public async Task<ActionResult> Get(long id)
        {
            try
            {
                return ValidateServiceResponse(await _requestService.GetByIdAsync(id));
            }
            catch (Exception e)
            {
                return BadRequest(Result.Fail(e.Message));
            }
        }

        [Route("requests/{id}")]
        [HttpPut]
        public async Task<ActionResult> Update(long id, [FromBody] RequestDto requestDto)
        {
            try
            {
                return ValidateServiceResponse(await _requestService.MapAndUpdateAsync(id, requestDto));
            }
            catch (Exception e)
            {
                return BadRequest(Result.Fail(e.Message));
            }
        }

        [Route("requests/{id}")]
        [HttpDelete]
        public async Task<ActionResult> Delete(long id)
        {
            try
            {
                return ValidateServiceResponse(await _requestService.RemoveAsync(id));
            }
            catch (Exception e)
            {
                return BadRequest(Result.Fail(e.Message));
            }
        }
    }
}
