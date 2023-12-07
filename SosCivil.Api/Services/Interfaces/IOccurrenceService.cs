using FluentResults;
using SosCivil.Api.Data.Entities;
using SosCivil.Api.Data.Entities.Mongo;
using SosCivil.Api.Services.Base.Interfaces;

namespace SosCivil.Api.Services.Interfaces
{
    public interface IOccurrenceService : ISosCivilServiceBase<Occurrence>
    {
        Task<Result<List<OccurrenceDocuments>?>> GetDocumentByIdAsync(long id);
    }
}