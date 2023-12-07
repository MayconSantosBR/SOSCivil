using SosCivil.Mvc.Models;

namespace SosCivil.Mvc.Service
{
    public interface IUserService
    {
        Task<MeuPerfilViewModel> GetUserPerson(string email);
    }
}
