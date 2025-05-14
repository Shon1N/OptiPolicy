using OptiPolicy.Api.DataTransferObjects;
using OptiPolicy.Api.Entities;
using OptiPolicy.Api.Enums;
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
                envelope.Result = nameof(StatusDescription.Passed);
                envelope.Message = "Query executed successfully.";
                envelope.StatusCode = (int)StatusCode.Ok;
            }
            catch (Exception ex)
            {
                envelope.Result = nameof(StatusDescription.Failed);
                envelope.Message = $"{ex.Message}";
                envelope.StatusCode = (int)StatusCode.InternalServerError;
            }
            return envelope;
        }

        public async Task<Envelope<UserDto>> GetByIdAsync(int userId)
        {
            var envelope = new Envelope<UserDto>();
            try
            {
                envelope.Response = await _userService.GetByIdAsync(userId);
                envelope.Result = nameof(StatusDescription.Passed);
                envelope.Message = "Query executed successfully.";
                envelope.StatusCode = (int)StatusCode.Ok;
            }
            catch (Exception ex)
            {
                envelope.Result = nameof(StatusDescription.Failed);
                envelope.Message = $"{ex.Message}";
                envelope.StatusCode = (int)StatusCode.InternalServerError;
            }
            return envelope;
        }
    }
}