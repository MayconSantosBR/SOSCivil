using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using SosCivil.Mvc.Models.Auth;
using SosCivil.Mvc.Service;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace SosCivil.Mvc.Controllers
{
    public class AuthController : MainController
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }


        [HttpGet]
        [Route("nova-conta")]
        public IActionResult Registro()
        {
            return View();
        }

        [HttpPost]
        [Route("nova-conta")]
        public async Task<IActionResult> Registro(UsuarioRegistroViewModel usuarioRegistro)
        {
            try
            {

                if (!ModelState.IsValid)
                    return View(usuarioRegistro);

                var res = await _authService.Registrar(usuarioRegistro);

                if (ResponsePossuiErros(res.ResponseResult))
                    return View(usuarioRegistro);

                await RealizarLogin(res);

                //Realizar login no app
                return RedirectToAction("Index", "Home");
            }
            catch (Exception e)
            {
                return View(usuarioRegistro);
            }

        }

        [HttpGet]
        [Route("login")]
        public IActionResult Login()
        {
            return View();
        }


        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> Login(UsuarioLoginViewModel usuarioLogin)
        {
            try
            {


                if (!ModelState.IsValid)
                    return View(usuarioLogin);

                var res = await _authService.Login(usuarioLogin);
                if (ResponsePossuiErros(res.ResponseResult))
                    return View(usuarioLogin);

                await RealizarLogin(res);

                return RedirectToAction("Index", "Home");
            }
            catch(Exception e)
            {
                return View(usuarioLogin);
            }

        }

        [HttpGet]
        [Route("sair")]
        public IActionResult Logout()
        {
            return RedirectToAction("Index", "Home");
        }

        private async Task RealizarLogin(UsuarioRespostaLogin res)
        {
            var token = ObterTokenFormatado(res.AccessToken);

            var claims = new List<Claim>();
            claims.Add(new Claim("JWT", res.AccessToken));
            claims.AddRange(token.Claims);

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);

            var authProperties = new AuthenticationProperties
            {
                ExpiresUtc = DateTimeOffset.Now.AddMinutes(60),
                IsPersistent = true
            };


            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                authProperties);
        }

        private static JwtSecurityToken ObterTokenFormatado(string jwtToken)
        {
            return new JwtSecurityTokenHandler().ReadToken(jwtToken) as JwtSecurityToken;
        }
    }
}
