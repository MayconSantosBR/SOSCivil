using SosCivil.Mvc.Models;

namespace SosCivil.Mvc.Service
{
    public interface IPersonService
    {
        Task<string> CreatePerson(PersonModel person, string token, string email);

    }
}
