using OptiPolicy.Shared.DataTransferObjects;

namespace OptiPolicy.Api.Services.Interfaces
{
    public interface IPermissionService
    {
        Task<PermissionDto> CreateAsync(PermissionDto permission);
        Task<PermissionDto> GetByIdAsync(int permissionId);
        Task<IEnumerable<PermissionDto>> GetAllAsync();
    }
}