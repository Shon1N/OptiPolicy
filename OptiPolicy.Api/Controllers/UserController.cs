using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OptiPolicy.Api.Authorization;
using OptiPolicy.Api.DataTransferObjects;
using OptiPolicy.Api.Features.User;

namespace OptiPolicy.Api.Controllers
{
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserCmd _userCmd;
        private readonly IUserQry _userQry;
        public UserController(IUserCmd userCmd, IUserQry userQry)
        {
            _userCmd = userCmd;
            _userQry = userQry;
        }

        [Route("api/[controller]/CreateAsync")]
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] UserDto userDto)
        {
            var envelope = await _userCmd.CreateAsync(userDto);
            return Ok(envelope);
        }

        [Route("api/[controller]/GetByIdAsync")]
        [HttpGet]
        public async Task<IActionResult> GetByIdAsync(int userId)
        {
            var envelope = await _userQry.GetByIdAsync(userId);
            return Ok(envelope);
        }

        [Route("api/[controller]/GetAllAsync")]
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var envelope = await _userQry.GetAllAsync();
            return Ok(envelope);
        }

        [Route("api/[controller]/UpdateAsync")]
        [HttpPost]
        public async Task<IActionResult> UpdateAsync([FromBody] UserDto userDto)
        {
            var envelope = await _userCmd.UpdateAsync(userDto);
            return Ok(envelope);
        }

        [Route("api/[controller]/DeleteAsync")]
        [HttpPost]
        public async Task<IActionResult> DeleteAsync([FromBody] UserDto userDto)
        {
            var envelope = await _userCmd.DeleteAsync(userDto);
            return Ok(envelope);
        }
    }
}