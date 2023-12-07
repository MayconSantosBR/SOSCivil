using SosCivil.Mvc.Extensions;

namespace SosCivil.Mvc.Service.Base
{
    public abstract class ServiceBase
    {
        protected bool TratarErrosResponse(HttpResponseMessage response)
        {
            switch ((int)response.StatusCode)
            {
                case 401:
                case 403:
                case 404:
                case 500:
                    throw new CustomHttpRequestException(response.StatusCode);
                case 400:
                    return false;

            }

            response.EnsureSuccessStatusCode();
            return true;
        }
    }
}
