using SosCivil.Mvc.Models;

namespace SosCivil.Mvc.Service.Interfaces
{
    public interface IItemService
    {
        Task<List<Suprimento>> PegarSuprimentosAssincrono();
        Task<bool> CriarSuprimentoAssincrono(Suprimento suprimento);
        Task<Suprimento> PegarSuprimentoPorIdAssincrono(long id);
        Task<bool> EditarSuprimentoAssincrono(Suprimento suprimento);
        Task<bool> ExcluirSuprimentoAssincrono(long id);
    }
}