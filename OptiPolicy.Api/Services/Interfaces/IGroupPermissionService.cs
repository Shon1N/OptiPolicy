using OptiPolicy.Api.DataTransferObjects;

namespace OptiPolicy.Api.Services.Interfaces
{
    public interface IGroupPermissionService
    {
        Task<GroupPermissionDto> CreateAsync(GroupPermissionDto permission);
        Task<GroupPermissionDto> GetByIdAsync(int groupPermissionId);
        Task<IEnumerable<GroupPermissionDto>> GetAllAsync();
    }
}