using SosCivil.Mvc.Models;

namespace SosCivil.Mvc.Service.Interfaces
{
    public interface IPersonService
    {
        Task<string> CreatePerson(PersonModel person, string token, string email);

    }
}
