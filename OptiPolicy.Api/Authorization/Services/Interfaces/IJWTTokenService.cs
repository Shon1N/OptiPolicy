using OptiPolicy.Shared.DataTransferObjects;

namespace OptiPolicy.Api.Authorization.Services.Interfaces
{
    public interface IJWTTokenService
    {
        Task<string> GenerateJwtToken(UserDto user, DateTime expiryDate);
    }
}