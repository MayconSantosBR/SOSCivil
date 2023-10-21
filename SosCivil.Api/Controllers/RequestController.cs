using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace SosCivil.Api.Controllers
{
    public class RequestController : ControllerBase
    {
        public async Task<ActionResult<Result>> All()
        {
            try
            {
                return Result.Ok();
            }
            catch(Exception e)
            {
                return Result.Fail(e.Message);
            }
        }
    }
}
