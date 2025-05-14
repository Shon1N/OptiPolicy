using OptiPolicy.Api.DataTransferObjects;

namespace OptiPolicy.Api.Services.Interfaces
{
    public interface IUserGroupService
    {
        Task<UserGroupDto> CreateAsync(UserGroupDto userGroup);
        Task<UserGroupDto> GetByIdAsync(int userGroupId);
        Task<IEnumerable<UserGroupDto>> GetAllAsync();
        Task<UserGroupDto> DeleteAsync(UserGroupDto userGroup);
    }
}