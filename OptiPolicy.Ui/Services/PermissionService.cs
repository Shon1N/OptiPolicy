using Newtonsoft.Json;
using OptiPolicy.Shared.DataTransferObjects;
using OptiPolicy.Shared.Enums;
using OptiPolicy.Ui.Services.Interfaces;

namespace OptiPolicy.Ui.Services
{
    public class PermissionService : IPermissionService
    {
        private readonly HttpClient _httpClient;
        private readonly IStateService _stateService;
        private readonly IRequestTokenService _requestTokenService;
        private const string _controller = "Permission";
        public PermissionService(HttpClient httpClient, IStateService stateService, IRequestTokenService requestTokenService)
        {
            _httpClient = httpClient;
            _stateService = stateService;
            _stateService = stateService;
            _requestTokenService = requestTokenService;
        }

        public async Task<Envelope<IEnumerable<PermissionDto>>> GetAllAsync()
        {
            var envelope = new Envelope<IEnumerable<PermissionDto>>();
            try
            {
                string token = _stateService.User?.Token;
                _requestTokenService.SetUpAuthProperties(token);
                string endpoint = $"api/{_controller}/GetAllAsync";
                var response = await _httpClient.GetAsync(endpoint);
                string dataResult = await response.Content.ReadAsStringAsync();
                envelope = JsonConvert.DeserializeObject<Envelope<IEnumerable<PermissionDto>>>(dataResult);
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

        public async Task<Envelope<PermissionDto>> GetByIdAsync(int groupPermissionId)
        {
            var envelope = new Envelope<PermissionDto>();
            try
            {
                string token = _stateService.User?.Token;
                _requestTokenService.SetUpAuthProperties(token);
                string endpoint = $"api/{_controller}/GetByIdAsync?{nameof(groupPermissionId)}={groupPermissionId}";
                var response = await _httpClient.GetAsync(endpoint);
                string dataResult = await response.Content.ReadAsStringAsync();
                envelope = JsonConvert.DeserializeObject<Envelope<PermissionDto>>(dataResult);
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