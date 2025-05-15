using OptiPolicy.Shared.DataTransferObjects;
using OptiPolicy.Shared.Enums;
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
                envelope.Result = nameof(StatusDescriptionEnum.Passed);
                envelope.Message = "Command executed successfully.";
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

        public async Task<Envelope<UserDto>> DeleteAsync(UserDto user)
        {
            var envelope = new Envelope<UserDto>();
            try
            {
                user.DeletionDate = DateTime.UtcNow;
                user.Username = user.Username + "_deleted";
                envelope.Response = await _userService.DeleteAsync(user);
                envelope.Result = nameof(StatusDescriptionEnum.Passed);
                envelope.Message = "Command executed successfully.";
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

        public async Task<Envelope<UserDto>> UpdateAsync(UserDto user)
        {
            var envelope = new Envelope<UserDto>();
            try
            {
                user.ModificationDate = DateTime.UtcNow;
                envelope.Response = await _userService.UpdateAsync(user);
                envelope.Result = nameof(StatusDescriptionEnum.Passed);
                envelope.Message = "Command executed successfully.";
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