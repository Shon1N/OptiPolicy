using OptiPolicy.Api.DataTransferObjects;

namespace OptiPolicy.Api.Features.User
{
    public interface IUserCmd
    {
        Task<Envelope<UserDto>> CreateAsync(UserDto userGroup);
        Task<Envelope<UserDto>> UpdateAsync(UserDto userGroup);
        Task<Envelope<UserDto>> DeleteAsync(UserDto userGroup);
    }
}