using OptiPolicy.Api.DataTransferObjects;

namespace OptiPolicy.Api.Features.User
{
    public interface IUserQry
    {
        Task<Envelope<UserDto>> GetByIdAsync(int userId);
        Task<Envelope<IEnumerable<UserDto>>> GetAllAsync();
    }
}