using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace SosCivil.Api.Controllers.Base
{
    public class SosCivilControllerBase : ControllerBase
    {
        protected ActionResult ValidateServiceResponse<T>(Result<T> result)
        {
            if (result.IsSuccess)
                return Ok(result.Value);
            else
                return BadRequest(result.Errors);
        }
    }
}
