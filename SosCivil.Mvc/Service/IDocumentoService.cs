using SosCivil.Mvc.Models;

namespace SosCivil.Mvc.Service
{
    public interface IDocumentoService
    {
        Task<string> NovoDocumento(IFormFile file);
    }
}
