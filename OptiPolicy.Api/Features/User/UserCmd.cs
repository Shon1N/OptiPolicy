using OptiPolicy.Api.DataTransferObjects;
using OptiPolicy.Api.Enums;
using OptiPolicy.Api.Services.Interfaces;

namespace OptiPolicy.Api.Features.User
{
    public class UserCmd : IUserCmd
    {
        private IUserService _userService;
        public UserCmd(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<Envelope<UserDto>> CreateAsync(UserDto user)
        {
            var envelope = new Envelope<UserDto>();
            try
            {
                user.CreationDate = DateTime.UtcNow;
                envelope.Response = await _userService.CreateAsync(user);
                envelope.Result = nameof(StatusDescription.Passed);
                envelope.Message = "Command executed successfully.";
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

        public async Task<Envelope<UserDto>> DeleteAsync(UserDto user)
        {
            var envelope = new Envelope<UserDto>();
            try
            {
                user.DeletionDate = DateTime.UtcNow;
                envelope.Response = await _userService.DeleteAsync(user);
                envelope.Result = nameof(StatusDescription.Passed);
                envelope.Message = "Command executed successfully.";
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

        public async Task<Envelope<UserDto>> UpdateAsync(UserDto user)
        {
            var envelope = new Envelope<UserDto>();
            try
            {
                user.ModificationDate = DateTime.UtcNow;
                envelope.Response = await _userService.UpdateAsync(user);
                envelope.Result = nameof(StatusDescription.Passed);
                envelope.Message = "Command executed successfully.";
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