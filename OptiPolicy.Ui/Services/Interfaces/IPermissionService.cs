using OptiPolicy.Shared.DataTransferObjects;

namespace OptiPolicy.Ui.Services.Interfaces
{
    public interface IPermissionService
    {
        Task<Envelope<PermissionDto>> GetByIdAsync(int groupPermissionId);
        Task<Envelope<IEnumerable<PermissionDto>>> GetAllAsync();
    }
}