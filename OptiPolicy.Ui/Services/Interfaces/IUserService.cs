using OptiPolicy.Shared.DataTransferObjects;

namespace OptiPolicy.Ui.Services.Interfaces
{
    public interface IUserService
    {
        Task<Envelope<UserDto>> CreateAsync(UserDto user);
        Task<Envelope<UserDto>> UpdateAsync(UserDto user);
        Task<Envelope<UserDto>> DeleteAsync(UserDto user);
        Task<Envelope<UserDto>> GetByIdAsync(int userId);
        Task<Envelope<IEnumerable<UserDto>>> GetAllAsync();
    }
}