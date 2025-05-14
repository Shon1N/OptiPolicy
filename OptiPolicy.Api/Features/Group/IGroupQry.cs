using OptiPolicy.Api.DataTransferObjects;

namespace OptiPolicy.Api.Features.Group
{
    public interface IGroupQry
    {
        Task<Envelope<GroupDto>> GetByIdAsync(int groupId);
        Task<Envelope<IEnumerable<GroupDto>>> GetAllAsync();
    }
}