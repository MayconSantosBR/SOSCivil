using SosCivil.Mvc.Models;

namespace SosCivil.Mvc.Service.Interfaces
{
    public interface IRequestService
    {
        Task<List<Entrega>> PegarEntregasAssincrono();
        Task<bool> CriarEntregaAssincrono(Entrega entrega);
        Task<Entrega> PegarEntregaPorIdAssincrono(long id);
        Task<bool> EditarEntregaAssincrono(Entrega entrega);
        Task<bool> ExcluirEntregaAssincrono(long id);
    }
}