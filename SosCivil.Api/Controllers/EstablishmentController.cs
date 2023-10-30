using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace SosCivil.Api.Controllers
{
    [ApiController]
    [Route("api/")]
    public class EstablishmentController : ControllerBase
    {
        [Route("establishments")]
        [HttpGet]
        public async Task<ActionResult<Result>> All()
        {
            try
            {
                return Result.Ok();
            }
            catch (Exception e)
            {
                return Result.Fail(e.Message);
            }
        }
    }
}
