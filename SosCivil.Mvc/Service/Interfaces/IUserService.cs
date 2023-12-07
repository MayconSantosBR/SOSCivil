using SosCivil.Mvc.Models;

namespace SosCivil.Mvc.Service.Interfaces
{
    public interface IUserService
    {
        Task<MeuPerfilViewModel> GetUserPerson(string email);
    }
}
