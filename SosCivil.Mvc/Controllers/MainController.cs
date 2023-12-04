using Microsoft.AspNetCore.Mvc;
using SosCivil.Mvc.Models;

namespace SosCivil.Mvc.Controllers
{
    public class MainController : Controller
    {
        protected bool ResponsePossuiErros(ResponseResult resposta)
        {
            if (resposta != null && resposta.Errors.Messages.Any())
                return true;
            return false;
        }
    }
}
