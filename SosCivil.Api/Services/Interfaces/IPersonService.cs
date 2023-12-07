using SosCivil.Api.Data.Entities;
using SosCivil.Api.Models.Dtos.Controllers;
using SosCivil.Api.Services.Base.Interfaces;

namespace SosCivil.Api.Services.Interfaces
{
    public interface IPersonService : ISosCivilServiceBase<Person>
    {
        Task<Person> CreateAndReturn(PersonDto personDto);
    }
}
