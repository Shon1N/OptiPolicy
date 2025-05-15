using Newtonsoft.Json;
using OptiPolicy.Shared.DataTransferObjects;
using OptiPolicy.Shared.Enums;
using OptiPolicy.Ui.Services.Interfaces;
using System.Net.Mime;
using System.Text;

namespace OptiPolicy.Ui.Services
{
    public class UserGroupService : IUserGroupService
    {
        private readonly HttpClient _httpClient;
        private readonly IStateService _stateService;
        private readonly IRequestTokenService _requestTokenService;
        private const string _controller = "UserGroup";
        public UserGroupService(HttpClient httpClient, IStateService stateService, IRequestTokenService requestTokenService)
        {
            _httpClient = httpClient;
            _stateService = stateService;
            _stateService = stateService;
            _requestTokenService = requestTokenService;
        }

        public async Task<Envelope<UserGroupDto>> CreateAsync(UserGroupDto userGroup)
        {
            var envelope = new Envelope<UserGroupDto>();
            try
            {
                string token = _stateService.User?.Token;
                _requestTokenService.SetUpAuthProperties(token);
                var authJson = new StringContent(JsonConvert.SerializeObject(userGroup), Encoding.UTF8, MediaTypeNames.Application.Json);
                string endpoint = $"api/{_controller}/CreateAsync";
                var response = await _httpClient.PostAsync(endpoint, authJson);
                string dataResult = await response.Content.ReadAsStringAsync();
                envelope = JsonConvert.DeserializeObject<Envelope<UserGroupDto>>(dataResult);
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

        public async Task<Envelope<UserGroupDto>> DeleteAsync(UserGroupDto userGroup)
        {
            var envelope = new Envelope<UserGroupDto>();
            try
            {
                string token = _stateService.User?.Token;
                _requestTokenService.SetUpAuthProperties(token);
                var authJson = new StringContent(JsonConvert.SerializeObject(userGroup), Encoding.UTF8, MediaTypeNames.Application.Json);
                string endpoint = $"api/{_controller}/DeleteAsync";
                var response = await _httpClient.PostAsync(endpoint, authJson);
                string dataResult = await response.Content.ReadAsStringAsync();
                envelope = JsonConvert.DeserializeObject<Envelope<UserGroupDto>>(dataResult);
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

        public async Task<Envelope<IEnumerable<UserGroupDto>>> GetAllAsync()
        {
            var envelope = new Envelope<IEnumerable<UserGroupDto>>();
            try
            {
                string token = _stateService.User?.Token;
                _requestTokenService.SetUpAuthProperties(token);
                string endpoint = $"api/{_controller}/GetAllAsync";
                var response = await _httpClient.GetAsync(endpoint);
                string dataResult = await response.Content.ReadAsStringAsync();
                envelope = JsonConvert.DeserializeObject<Envelope<IEnumerable<UserGroupDto>>>(dataResult);
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

        public async Task<Envelope<UserGroupDto>> GetByIdAsync(int userGroupId)
        {
            var envelope = new Envelope<UserGroupDto>();
            try
            {
                string token = _stateService.User?.Token;
                _requestTokenService.SetUpAuthProperties(token);
                string endpoint = $"api/{_controller}/GetByIdAsync?{nameof(userGroupId)}={userGroupId}";
                var response = await _httpClient.GetAsync(endpoint);
                string dataResult = await response.Content.ReadAsStringAsync();
                envelope = JsonConvert.DeserializeObject<Envelope<UserGroupDto>>(dataResult);
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