using RestSharp;

namespace SaleInStore.Core.Services.Implementation
{
    public class AuthHelper:IAuthHelper
    {
        private readonly RestClient _restClient;
        public AuthHelper(RestClient restClient)
        {
            _restClient = restClient;
        }
    }
}
