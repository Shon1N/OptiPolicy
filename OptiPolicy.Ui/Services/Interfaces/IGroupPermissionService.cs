using OptiPolicy.Shared.DataTransferObjects;

namespace OptiPolicy.Ui.Services.Interfaces
{
    public interface IGroupPermissionService
    {
        Task<Envelope<GroupPermissionDto>> GetByIdAsync(int groupPermissionId);
        Task<Envelope<IEnumerable<GroupPermissionDto>>> GetAllAsync();
    }
}