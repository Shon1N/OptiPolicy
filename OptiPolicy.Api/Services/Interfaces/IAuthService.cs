using OptiPolicy.Shared.DataTransferObjects;

namespace OptiPolicy.Api.Services.Interfaces
{
    public interface IAuthService
    {
        Task<AuthDto> LoginAsync(LoginDto loginDto);
        Task<string> LogOutAsync(int userId);
    }
}