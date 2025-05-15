using OptiPolicy.Shared.DataTransferObjects;
using OptiPolicy.Api.Entities;
using OptiPolicy.Shared.Enums;
using OptiPolicy.Api.Services;
using OptiPolicy.Api.Services.Interfaces;

namespace OptiPolicy.Api.Features.User
{
    public class UserQry : IUserQry
    {
        private IUserService _userService;
        public UserQry(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<Envelope<IEnumerable<UserDto>>> GetAllAsync()
        {
            var envelope = new Envelope<IEnumerable<UserDto>>();
            try
            {
                envelope.Response = await _userService.GetAllAsync();
                envelope.Result = nameof(StatusDescriptionEnum.Passed);
                envelope.Message = "Query executed successfully.";
                envelope.StatusCode = (int)StatusCodeEnum.Ok;
            }
            catch (Exception ex)
            {
                envelope.Result = nameof(StatusDescriptionEnum.Failed);
                envelope.Message = $"{ex.Message}";
                envelope.StatusCode = (int)StatusCodeEnum.InternalServerError;
            }
            return envelope;
        }

        public async Task<Envelope<UserDto>> GetByIdAsync(int userId)
        {
            var envelope = new Envelope<UserDto>();
            try
            {
                envelope.Response = await _userService.GetByIdAsync(userId);
                envelope.Result = nameof(StatusDescriptionEnum.Passed);
                envelope.Message = "Query executed successfully.";
                envelope.StatusCode = (int)StatusCodeEnum.Ok;
            }
            catch (Exception ex)
            {
                envelope.Result = nameof(StatusDescriptionEnum.Failed);
                envelope.Message = $"{ex.Message}";
                envelope.StatusCode = (int)StatusCodeEnum.InternalServerError;
            }
            return envelope;
        }

        public async Task<Envelope<int>> GetUserCountAsync()
        {
            var envelope = new Envelope<int>();
            try
            {
                envelope.Response = await _userService.GetUserCountAsync();
                envelope.Result = nameof(StatusDescriptionEnum.Passed);
                envelope.Message = "Query executed successfully.";
                envelope.StatusCode = (int)StatusCodeEnum.Ok;
            }
            catch (Exception ex)
            {
                envelope.Result = nameof(StatusDescriptionEnum.Failed);
                envelope.Message = $"{ex.Message}";
                envelope.StatusCode = (int)StatusCodeEnum.InternalServerError;
            }
            return envelope;
        }

        public async Task<Envelope<int>> GetUserCountByGroupId(int groupId)
        {
            var envelope = new Envelope<int>();
            try
            {
                envelope.Response = await _userService.GetUserCountByGroupIdAsync(groupId);
                envelope.Result = nameof(StatusDescriptionEnum.Passed);
                envelope.Message = "Query executed successfully.";
                envelope.StatusCode = (int)StatusCodeEnum.Ok;
            }
            catch (Exception ex)
            {
                envelope.Result = nameof(StatusDescriptionEnum.Failed);
                envelope.Message = $"{ex.Message}";
                envelope.StatusCode = (int)StatusCodeEnum.InternalServerError;
            }
            return envelope;
        }
    }
}