using Newtonsoft.Json;
using OptiPolicy.Shared.DataTransferObjects;
using OptiPolicy.Shared.Enums;
using OptiPolicy.Ui.Services.Interfaces;
using System.Net.Mime;
using System.Text;

namespace OptiPolicy.Ui.Services
{
    public class AuthService : IAuthService
    {
        private readonly HttpClient _httpClient;
        private const string _controller = "Auth";
        public AuthService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public async Task<Envelope<AuthDto>> LoginAsync(LoginDto loginDto)
        {
            var envelope = new Envelope<AuthDto>();
            try
            {
                var authJson = new StringContent(JsonConvert.SerializeObject(loginDto), Encoding.UTF8, MediaTypeNames.Application.Json);
                string endpoint = $"api/{_controller}/LoginAsync";
                var response = await _httpClient.PostAsync(endpoint, authJson);
                string dataResult = await response.Content.ReadAsStringAsync();
                envelope = JsonConvert.DeserializeObject<Envelope<AuthDto>>(dataResult);
                return envelope;
            }
            catch (Exception ex)
            {
                envelope.Result = nameof(StatusDescriptionEnum.Failed);
                envelope.Message = ex.Message;
                envelope.StatusCode = (int)StatusCodeEnum.InternalServerError;
                return envelope;
            }
        }
    }
}