using Microsoft.AspNetCore.Mvc;

namespace SosCivil.Mvc.Controllers
{
    public class ErrorController : Controller
    {
        private readonly Dictionary<int, string> ErrorViewMap = new Dictionary<int, string>
        {
            { 400, "/Views/Error/400.cshtml" },
            { 401, "/Views/Error/401.cshtml" },
            { 403, "/Views/Error/403.cshtml" },
            { 404, "/Views/Error/404.cshtml" },
            { 500, "/Views/Error/500.cshtml" },
            { 502, "/Views/Error/503.cshtml" },
            { 504, "/Views/Error/504.cshtml" },
        };

        [Route("Error/{statusCode}")]
        public IActionResult HandleError(int? statusCode)
        {
            if (statusCode.HasValue && ErrorViewMap.ContainsKey(statusCode.Value))
            {
                return View(ErrorViewMap[statusCode.Value]);
            }

            return View("/Views/Error/GenericError.cshtml");
        }
    }
}
