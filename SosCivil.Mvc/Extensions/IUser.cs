using System.Security.Claims;

namespace SosCivil.Mvc.Extensions
{
    public interface IUser
    {
        string Name { get; }
        Guid ObterUserId();
        string ObterUserEmail();
        string ObterUserToken();
        bool EstaAutenticado();
        bool PossuiuRole(string role);
        IEnumerable<Claim> ObterClaims();
        HttpContext ObterHttpContext();

    }
}
