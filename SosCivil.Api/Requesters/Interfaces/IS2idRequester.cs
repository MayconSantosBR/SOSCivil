using FluentResults;
using SosCivil.Api.Models.Dtos.Requesters.S2id;

namespace SosCivil.Api.Requesters.Interfaces
{
    public interface IS2idRequester
    {
        Task<List<S2idCobradeResponseDto>?> GetCobradeAsync();
    }
}