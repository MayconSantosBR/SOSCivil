using SosCivil.Mvc.Models.Auth;

namespace SosCivil.Mvc.Service
{
    public interface IAuthService
    {
        Task<UsuarioRespostaLogin> Login(UsuarioLoginViewModel userLogin);
        Task<UsuarioRespostaLogin> Registrar(UsuarioRegistroViewModel userRegistro);
    }
}
