using OptiPolicy.Shared.DataTransferObjects;

namespace OptiPolicy.Ui.Services.Interfaces
{
    public interface IAuthService
    {
        Task<Envelope<AuthDto>> LoginAsync(LoginDto loginDto);
    }
}