﻿using FluentResults;
using Microsoft.AspNetCore.Mvc;

namespace SosCivil.Api.Controllers
{
    [ApiController]
    [Route("api/")]
    public class RequestController : ControllerBase
    {
        [Route("requests")]
        [HttpGet]
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
