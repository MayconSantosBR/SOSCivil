using FluentResults;
using Microsoft.AspNetCore.Mvc;
using SosCivil.Api.Controllers.Base;
using SosCivil.Api.Services;
using SosCivil.Api.Services.Interfaces;

namespace SosCivil.Api.Controllers
{
    [ApiController]
    [Route("api/")]
    public class OccurrenceController : SosCivilControllerBase
    {
        private readonly IOccurrenceService _occurrenceService;

        public OccurrenceController(IOccurrenceService occurrenceService)
        {
            _occurrenceService = occurrenceService;
        }

        [Route("occurrences")]
        [HttpGet]
        public async Task<ActionResult> All()
        {
            try
            {
                return ValidateServiceResponse(await _occurrenceService.GetAllAsync());
            }
            catch (Exception e)
            {
                return BadRequest(Result.Fail(e.Message));
            }
        }

        [Route("occurrences/{id}")]
        [HttpGet]
        public async Task<ActionResult> Get(long id)
        {
            try
            {
                return ValidateServiceResponse(await _occurrenceService.GetByIdAsync(id));
            }
            catch (Exception e)
            {
                return BadRequest(Result.Fail(e.Message));
            }
        }
    }
}
