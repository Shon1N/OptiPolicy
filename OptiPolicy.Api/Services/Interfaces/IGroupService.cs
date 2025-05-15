using OptiPolicy.Shared.DataTransferObjects;

namespace OptiPolicy.Api.Services.Interfaces
{
    public interface IGroupService
    {
        Task<GroupDto> CreateAsync(GroupDto group);
        Task<GroupDto> GetByIdAsync(int groupId);
        Task<IEnumerable<GroupDto>> GetAllAsync();
    }
}