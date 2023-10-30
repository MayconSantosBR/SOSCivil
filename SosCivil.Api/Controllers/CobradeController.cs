using FluentResults;
using Microsoft.AspNetCore.Mvc;
using SosCivil.Api.Data.Entities;
using SosCivil.Api.Services;

namespace SosCivil.Api.Controllers
{
    [ApiController]
    [Route("api/")]
    public class CobradeController : ControllerBase
    {
        private readonly ICobradeService _cobradeService;

        public CobradeController(ICobradeService cobradeService)
        {
            _cobradeService = cobradeService;
        }

        [Route("cobrades")]
        [HttpGet]
        public async Task<ActionResult> All()
        {
            try
            {
                return ValidateServiceResponse(await _cobradeService.AllAsync());
            }
            catch (Exception e)
            {
                return BadRequest(e.Message);
            }
        }

        [Route("cobrades/sync")]
        [HttpPatch]
        public async Task<ActionResult> RequestCobradeTableSync()
        {
            try
            {
                return ValidateServiceResponse<List<Cobrade>>(await _cobradeService.CreateOrUpdateCobradeAsync());
            }
            catch (Exception e)
            {
                return BadRequest(Result.Fail(e.Message));
            }
        }

        private ActionResult ValidateServiceResponse<T>(Result<T> result)
        {
            if (result.IsSuccess)
                return Ok(result.Value);
            else
                return BadRequest(result.Errors);
        }
    }
}
