using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using SosCivil.Mvc.Extensions;
using SosCivil.Mvc.Service;

namespace SosCivil.Mvc.Controllers
{
    public class MeuPerfilController : Controller
    {
        private readonly IUser _user;
        private readonly IUserService _userService;
        public MeuPerfilController(IUser user, IUserService userService)
        {
            _user = user;
            _userService = userService;
        }
        public async Task<IActionResult> Index()
        {
            var email = _user.ObterUserEmail();
            var userModel = await _userService.GetUserPerson(email);

            return View(userModel);
        }
    }
}
