using OptiPolicy.Ui.Services.Interfaces;
using System.Net.Http.Headers;

namespace OptiPolicy.Ui.Services
{
    public class RequestTokenService : IRequestTokenService
    {
        private readonly HttpClient _httpClient;
        public RequestTokenService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public void SetUpAuthProperties(string token)
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", token);
        }
    }
}