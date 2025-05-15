using OptiPolicy.Shared.DataTransferObjects;
using OptiPolicy.Api.Entities;
using OptiPolicy.Shared.Enums;
using OptiPolicy.Api.Services;
using OptiPolicy.Api.Services.Interfaces;

namespace OptiPolicy.Api.Features.UserGroup
{
    public class UserGroupCmd : IUserGroupCmd
    {
        private IUserGroupService _userGroupService;
        public UserGroupCmd(IUserGroupService userGroupService)
        {
            _userGroupService = userGroupService;
        }

        public async Task<Envelope<UserGroupDto>> CreateAsync(UserGroupDto userGroup)
        {
            var envelope = new Envelope<UserGroupDto>();
            try
            {
                userGroup.CreationDate = DateTime.UtcNow;
                envelope.Response = await _userGroupService.CreateAsync(userGroup);
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

        public async Task<Envelope<UserGroupDto>> DeleteAsync(UserGroupDto userGroup)
        {
            var envelope = new Envelope<UserGroupDto>();
            try
            {
                userGroup.DeletionDate = DateTime.UtcNow;
                envelope.Response = await _userGroupService.DeleteAsync(userGroup);
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