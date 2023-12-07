using SosCivil.Mvc.Models;
using SosCivil.Mvc.Models.Auth;

namespace SosCivil.Mvc.Service
{
    public interface ISolicitacaoService
    {
        Task<List<Solicitacao>> GetAllSolicitacoes();
    }
}
