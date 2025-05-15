using OptiPolicy.Shared.DataTransferObjects;

namespace OptiPolicy.Api.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserDto> CreateAsync(UserDto user);
        Task<UserDto> GetByIdAsync(int userId);
        Task<IEnumerable<UserDto>> GetAllAsync();
        Task<UserDto> UpdateAsync(UserDto user);
        Task<UserDto> DeleteAsync(UserDto user);
    }
}