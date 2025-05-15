using Newtonsoft.Json;
using OptiPolicy.Shared.DataTransferObjects;
using OptiPolicy.Shared.Enums;
using OptiPolicy.Ui.Services.Interfaces;

namespace OptiPolicy.Ui.Services
{
    public class GroupService : IGroupService
    {
        private readonly HttpClient _httpClient;
        private readonly IStateService _stateService;
        private readonly IRequestTokenService _requestTokenService;
        private const string _controller = "Group";
        public GroupService(HttpClient httpClient, IStateService stateService, IRequestTokenService requestTokenService)
        {
            _httpClient = httpClient;
            _stateService = stateService;
            _stateService = stateService;
            _requestTokenService = requestTokenService;
        }

        public async Task<Envelope<IEnumerable<GroupDto>>> GetAllAsync()
        {
            var envelope = new Envelope<IEnumerable<GroupDto>>();
            try
            {
                string token = _stateService.User?.Token;
                _requestTokenService.SetUpAuthProperties(token);
                string endpoint = $"api/{_controller}/GetAllAsync";
                var response = await _httpClient.GetAsync(endpoint);
                string dataResult = await response.Content.ReadAsStringAsync();
                envelope = JsonConvert.DeserializeObject<Envelope<IEnumerable<GroupDto>>>(dataResult);
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

        public async Task<Envelope<GroupDto>> GetByIdAsync(int groupId)
        {
            var envelope = new Envelope<GroupDto>();
            try
            {
                string token = _stateService.User?.Token;
                _requestTokenService.SetUpAuthProperties(token);
                string endpoint = $"api/{_controller}/GetByIdAsync?{nameof(groupId)}={groupId}";
                var response = await _httpClient.GetAsync(endpoint);
                string dataResult = await response.Content.ReadAsStringAsync();
                envelope = JsonConvert.DeserializeObject<Envelope<GroupDto>>(dataResult);
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