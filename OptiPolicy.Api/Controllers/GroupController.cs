using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OptiPolicy.Api.Authorization;
using OptiPolicy.Api.Features.Group;

namespace OptiPolicy.Api.Controllers
{
    [ApiController]
    public class GroupController : ControllerBase
    {
        private readonly IGroupQry _groupQry;
        public GroupController(IGroupQry groupQry)
        {
            _groupQry = groupQry;
        }

        [Route("api/[controller]/GetByIdAsync")]
        [HttpGet]
        [Authorize(Policy = SysRole.Read)]
        public async Task<IActionResult> GetByIdAsync(int groupId)
        {
            var envelope = await _groupQry.GetByIdAsync(groupId);
            return Ok(envelope);
        }

        [Route("api/[controller]/GetAllAsync")]
        [HttpGet]
        [Authorize(Policy = SysRole.Read)]
        public async Task<IActionResult> GetAllAsync()
        {
            var envelope = await _groupQry.GetAllAsync();
            return Ok(envelope);
        }
    }
}