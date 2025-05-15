using OptiPolicy.Shared.DataTransferObjects;

namespace OptiPolicy.Api.Features.UserGroup
{
    public interface IUserGroupQry
    {
        Task<Envelope<UserGroupDto>> GetByIdAsync(int userGroupId);
        Task<Envelope<IEnumerable<UserGroupDto>>> GetAllAsync();
    }
}
