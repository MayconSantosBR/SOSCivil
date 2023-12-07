
using SosCivil.Mvc.Models;
using System;
using System.Text.Json;

namespace SosCivil.Mvc.Service
{
    public class DocumentoService : IDocumentoService
    {
        private readonly HttpClient _httpClient;

        public DocumentoService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<string> NovoDocumento(IFormFile file)
        {
            var url = string.Empty;
            try
            {
                using (var content = new MultipartFormDataContent())
                {
                    using (var fileStream = file.OpenReadStream())
                    using (var streamContent = new StreamContent(fileStream))
                    {
                        content.Add(streamContent, "file", file.FileName);

                        var response = await _httpClient.PostAsync("https://localhost:7021/api/bucket/documents", content);
                        
                        var docRes = JsonSerializer.Deserialize<DocumentoResponse>(await response.Content.ReadAsStringAsync());
                        url = docRes.Url;
                    }
                }
                return url;
            }
            catch (Exception e)
            {
                return url;
            }

        }
    }
}
