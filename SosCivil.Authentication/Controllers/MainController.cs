using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.Runtime.CompilerServices;

namespace SosCivil.Authentication.Controllers
{
    [ApiController]
    public abstract class MainController : Controller
    {

        public ICollection<string> Errors = new List<string>();
        protected ActionResult CustomResponse(object result = null)
        {
            if (OperacaoValida())
                return Ok(result);

            return BadRequest(new ValidationProblemDetails(new Dictionary<string, string[]>
            {
                { "Messages", Errors.ToArray() }
            }));
        }

        protected ActionResult CustomResponse(ModelStateDictionary modelState)
        {
            var errors = modelState.Values.SelectMany(e => e.Errors);
            foreach (var error in errors)
                AddProcessingError(error.ErrorMessage);

            return CustomResponse();
        }

        protected bool OperacaoValida()
            => !Errors.Any();

        protected void AddProcessingError(string error) 
            => Errors.Add(error);

        protected void ClearProcessingErrors() 
            => Errors.Clear();
    }
}
