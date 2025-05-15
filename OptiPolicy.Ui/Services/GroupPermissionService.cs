using Newtonsoft.Json;
using OptiPolicy.Shared.DataTransferObjects;
using OptiPolicy.Shared.Enums;
using OptiPolicy.Ui.Services.Interfaces;

namespace OptiPolicy.Ui.Services
{
    public class GroupPermissionService : IGroupPermissionService
    {
        private readonly HttpClient _httpClient;
        private readonly IStateService _stateService;
        private readonly IRequestTokenService _requestTokenService;
        private const string _controller = "GroupPermission";
        public GroupPermissionService(HttpClient httpClient, IStateService stateService, IRequestTokenService requestTokenService)
        {
            _httpClient = httpClient;
            _stateService = stateService;
            _stateService = stateService;
            _requestTokenService = requestTokenService;
        }

        public async Task<Envelope<IEnumerable<GroupPermissionDto>>> GetAllAsync()
        {
            var envelope = new Envelope<IEnumerable<GroupPermissionDto>>();
            try
            {
                string token = _stateService.User?.Token;
                _requestTokenService.SetUpAuthProperties(token);
                string endpoint = $"api/{_controller}/GetAllAsync";
                var response = await _httpClient.GetAsync(endpoint);
                string dataResult = await response.Content.ReadAsStringAsync();
                envelope = JsonConvert.DeserializeObject<Envelope<IEnumerable<GroupPermissionDto>>>(dataResult);
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

        public async Task<Envelope<GroupPermissionDto>> GetByIdAsync(int groupPermissionId)
        {
            var envelope = new Envelope<GroupPermissionDto>();
            try
            {
                string token = _stateService.User?.Token;
                _requestTokenService.SetUpAuthProperties(token);
                string endpoint = $"api/{_controller}/GetByIdAsync?{nameof(groupPermissionId)}={groupPermissionId}";
                var response = await _httpClient.GetAsync(endpoint);
                string dataResult = await response.Content.ReadAsStringAsync();
                envelope = JsonConvert.DeserializeObject<Envelope<GroupPermissionDto>>(dataResult);
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