using OptiPolicy.Shared.DataTransferObjects;
using OptiPolicy.Api.Entities;
using OptiPolicy.Shared.Enums;
using OptiPolicy.Api.Services;
using OptiPolicy.Api.Services.Interfaces;

namespace OptiPolicy.Api.Features.Auth
{
    public class AuthQry : IAuthQry
    {
        private readonly IAuthService _authService;
        public AuthQry(IAuthService authService)
        {
            _authService = authService;
        }

        public async Task<Envelope<AuthDto>> LoginAsync(LoginDto loginDto)
        {
            var envelope = new Envelope<AuthDto>();
            try
            {
                envelope.Response = await _authService.LoginAsync(loginDto);
                envelope.Result = nameof(StatusDescriptionEnum.Passed);
                envelope.Message = "Query executed successfully.";
                envelope.StatusCode = (int)StatusCodeEnum.Ok;

            }
            catch (Exception ex)
            {
                envelope.Result = nameof(StatusDescriptionEnum.Failed);
                envelope.Message = $"{ex.Message}";
                envelope.StatusCode = (int)StatusCodeEnum.InternalServerError;
            }
            return envelope;
        }

        public Task<Envelope<string>> LogOutAsync(int userId)
        {
            throw new NotImplementedException();
        }
    }
}