using OptiPolicy.Shared.DataTransferObjects;

namespace OptiPolicy.Api.Features.User
{
    public interface IUserCmd
    {
        Task<Envelope<UserDto>> CreateAsync(UserDto user);
        Task<Envelope<UserDto>> UpdateAsync(UserDto user);
        Task<Envelope<UserDto>> DeleteAsync(UserDto user);
    }
}