using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OptiPolicy.Api.DataTransferObjects;
using OptiPolicy.Api.Features.UserGroup;

namespace OptiPolicy.Api.Controllers
{
    [ApiController]
    public class UserGroupController : ControllerBase
    {
        private readonly IUserGroupCmd _userGroupCmd;
        private readonly IUserGroupQry _userGroupQry;
        public UserGroupController(IUserGroupCmd userGroupCmd, IUserGroupQry userGroupQry)
        {
            _userGroupCmd = userGroupCmd;
            _userGroupQry = userGroupQry;
        }

        [Route("api/[controller]/CreateAsync")]
        [HttpPost]
        public async Task<IActionResult> CreateAsync([FromBody] UserGroupDto userGroupDto)
        {
            var envelope = await _userGroupCmd.CreateAsync(userGroupDto);
            return Ok(envelope);
        }

        [Route("api/[controller]/GetByIdAsync")]
        [HttpGet]
        public async Task<IActionResult> GetByIdAsync(int userGroupId)
        {
            var envelope = await _userGroupQry.GetByIdAsync(userGroupId);
            return Ok(envelope);
        }

        [Route("api/[controller]/GetAllAsync")]
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var envelope = await _userGroupQry.GetAllAsync();
            return Ok(envelope);
        }

        [Route("api/[controller]/DeleteAsync")]
        [HttpPost]
        public async Task<IActionResult> DeleteAsync([FromBody] UserGroupDto userGroupDto)
        {
            var envelope = await _userGroupCmd.DeleteAsync(userGroupDto);
            return Ok(envelope);
        }
    }
}