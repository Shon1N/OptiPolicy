using OptiPolicy.Api.DataTransferObjects;

namespace OptiPolicy.Api.Features.GroupPermission
{
    public interface IGroupPermissionQry
    {
        Task<Envelope<GroupPermissionDto>> GetByIdAsync(int groupPermissionId);
        Task<Envelope<IEnumerable<GroupPermissionDto>>> GetAllAsync();
    }
}
