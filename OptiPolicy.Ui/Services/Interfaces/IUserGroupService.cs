using OptiPolicy.Shared.DataTransferObjects;

namespace OptiPolicy.Ui.Services.Interfaces
{
    public interface IUserGroupService
    {
        Task<Envelope<UserGroupDto>> CreateAsync(UserGroupDto userGroup);
        Task<Envelope<UserGroupDto>> DeleteAsync(UserGroupDto userGroup);
        Task<Envelope<UserGroupDto>> GetByIdAsync(int userGroupId);
        Task<Envelope<IEnumerable<UserGroupDto>>> GetAllAsync();
    }
}