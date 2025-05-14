using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OptiPolicy.Api.Features.GroupPermission;

namespace OptiPolicy.Api.Controllers
{
    [ApiController]
    public class GroupPermissionController : ControllerBase
    {
        private readonly IGroupPermissionQry _groupPermissionQry;
        public GroupPermissionController(IGroupPermissionQry groupPermissionQry)
        {
            _groupPermissionQry = groupPermissionQry;
        }

        [Route("api/[controller]/GetByIdAsync")]
        [HttpGet]
        public async Task<IActionResult> GetByIdAsync(int groupPermissionId)
        {
            var envelope = await _groupPermissionQry.GetByIdAsync(groupPermissionId);
            return Ok(envelope);
        }

        [Route("api/[controller]/GetAllAsync")]
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var envelope = await _groupPermissionQry.GetAllAsync();
            return Ok(envelope);
        }
    }
}
