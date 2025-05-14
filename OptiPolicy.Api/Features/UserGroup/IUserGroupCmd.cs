using OptiPolicy.Api.DataTransferObjects;

namespace OptiPolicy.Api.Features.UserGroup
{
    public interface IUserGroupCmd
    {
        Task<Envelope<UserGroupDto>> CreateAsync(UserGroupDto userGroup);
        Task<Envelope<UserGroupDto>> DeleteAsync(UserGroupDto userGroup);
    }
}