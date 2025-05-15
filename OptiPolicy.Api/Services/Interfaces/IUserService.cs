using OptiPolicy.Shared.DataTransferObjects;

namespace OptiPolicy.Api.Services.Interfaces
{
    public interface IUserService
    {
        Task<UserDto> CreateAsync(UserDto user);
        Task<UserDto> GetByIdAsync(int userId);
        Task<IEnumerable<UserDto>> GetAllAsync();
        Task<int> GetUserCountAsync();
        Task<int> GetUserCountByGroupIdAsync(int groupId);
        Task<UserDto> UpdateAsync(UserDto user);
        Task<UserDto> DeleteAsync(UserDto user);
    }
}