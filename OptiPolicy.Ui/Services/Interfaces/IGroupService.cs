using OptiPolicy.Shared.DataTransferObjects;

namespace OptiPolicy.Ui.Services.Interfaces
{
    public interface IGroupService
    {
        Task<Envelope<GroupDto>> GetByIdAsync(int groupId);
        Task<Envelope<IEnumerable<GroupDto>>> GetAllAsync();
    }
}