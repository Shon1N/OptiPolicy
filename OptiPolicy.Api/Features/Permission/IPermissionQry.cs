using OptiPolicy.Shared.DataTransferObjects;

namespace OptiPolicy.Api.Features.Permission
{
    public interface IPermissionQry
    {
        Task<Envelope<PermissionDto>> GetByIdAsync(int groupPermissionId);
        Task<Envelope<IEnumerable<PermissionDto>>> GetAllAsync();
    }
}
