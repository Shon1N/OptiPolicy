using Newtonsoft.Json;
using OptiPolicy.Shared.DataTransferObjects;
using OptiPolicy.Shared.Enums;
using OptiPolicy.Ui.Services.Interfaces;
using System.Net.Mime;
using System.Text;

namespace OptiPolicy.Ui.Services
{
    public class UserService : IUserService
    {
        private readonly HttpClient _httpClient;
        private readonly IStateService _stateService;
        private readonly IRequestTokenService _requestTokenService;
        private const string _controller = "User";
        public UserService(HttpClient httpClient, IStateService stateService, IRequestTokenService requestTokenService)
        {
            _httpClient = httpClient;
            _stateService = stateService;
            _stateService = stateService;
            _requestTokenService = requestTokenService;
        }

        public async Task<Envelope<UserDto>> CreateAsync(UserDto user)
        {
            var envelope = new Envelope<UserDto>();
            try
            {
                string token = _stateService.User?.Token;
                _requestTokenService.SetUpAuthProperties(token);
                var authJson = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, MediaTypeNames.Application.Json);
                string endpoint = $"api/{_controller}/CreateAsync";
                var response = await _httpClient.PostAsync(endpoint, authJson);
                string dataResult = await response.Content.ReadAsStringAsync();
                envelope = JsonConvert.DeserializeObject<Envelope<UserDto>>(dataResult);
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

        public async Task<Envelope<UserDto>> DeleteAsync(UserDto user)
        {
            var envelope = new Envelope<UserDto>();
            try
            {
                string token = _stateService.User?.Token;
                _requestTokenService.SetUpAuthProperties(token);
                var authJson = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, MediaTypeNames.Application.Json);
                string endpoint = $"api/{_controller}/DeleteAsync";
                var response = await _httpClient.PostAsync(endpoint, authJson);
                string dataResult = await response.Content.ReadAsStringAsync();
                envelope = JsonConvert.DeserializeObject<Envelope<UserDto>>(dataResult);
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

        public async Task<Envelope<IEnumerable<UserDto>>> GetAllAsync()
        {
            var envelope = new Envelope<IEnumerable<UserDto>>();
            try
            {
                string token = _stateService.User?.Token;
                _requestTokenService.SetUpAuthProperties(token);
                string endpoint = $"api/{_controller}/GetAllAsync";
                var response = await _httpClient.GetAsync(endpoint);
                string dataResult = await response.Content.ReadAsStringAsync();
                envelope = JsonConvert.DeserializeObject<Envelope<IEnumerable<UserDto>>>(dataResult);
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

        public async Task<Envelope<UserDto>> GetByIdAsync(int userId)
        {
            var envelope = new Envelope<UserDto>();
            try
            {
                string token = _stateService.User?.Token;
                _requestTokenService.SetUpAuthProperties(token);
                string endpoint = $"api/{_controller}/GetByIdAsync?{nameof(userId)}={userId}";
                var response = await _httpClient.GetAsync(endpoint);
                string dataResult = await response.Content.ReadAsStringAsync();
                envelope = JsonConvert.DeserializeObject<Envelope<UserDto>>(dataResult);
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

        public async Task<Envelope<UserDto>> UpdateAsync(UserDto user)
        {
            var envelope = new Envelope<UserDto>();
            try
            {
                string token = _stateService.User?.Token;
                _requestTokenService.SetUpAuthProperties(token);
                var authJson = new StringContent(JsonConvert.SerializeObject(user), Encoding.UTF8, MediaTypeNames.Application.Json);
                string endpoint = $"api/{_controller}/UpdateAsync";
                var response = await _httpClient.PostAsync(endpoint, authJson);
                string dataResult = await response.Content.ReadAsStringAsync();
                envelope = JsonConvert.DeserializeObject<Envelope<UserDto>>(dataResult);
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