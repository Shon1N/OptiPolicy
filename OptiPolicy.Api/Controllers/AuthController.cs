using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OptiPolicy.Shared.DataTransferObjects;
using OptiPolicy.Api.Features.Auth;

namespace OptiPolicy.Api.Controllers
{
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IAuthQry _authQry;
        public AuthController(IAuthQry authQry)
        {
            _authQry = authQry;
        }


        [Route("api/[controller]/LoginAsync")]
        [HttpPost]
        public async Task<IActionResult> LoginAsync([FromBody] LoginDto loginDto)
        {
            var authUser = await _authQry.LoginAsync(loginDto);
            return Ok(authUser);
        }
    }
}