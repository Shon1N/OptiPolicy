using OptiPolicy.Api.DataTransferObjects;

namespace OptiPolicy.Api.Features.Auth
{
    public interface IAuthQry
    {
        Task<Envelope<AuthDto>> LoginAsync(LoginDto loginDto);
        Task<Envelope<string>> LogOutAsync(int userId);
    }
}