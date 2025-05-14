using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OptiPolicy.Api.Features.Permission;

namespace OptiPolicy.Api.Controllers
{
    [ApiController]
    public class PermissionController : ControllerBase
    {
        private readonly IPermissionQry _permissionQry;
        public PermissionController(IPermissionQry permissionQry)
        {
            _permissionQry = permissionQry;
        }

        [Route("api/[controller]/GetByIdAsync")]
        [HttpGet]
        public async Task<IActionResult> GetByIdAsync(int groupPermissionId)
        {
            var envelope = await _permissionQry.GetByIdAsync(groupPermissionId);
            return Ok(envelope);
        }

        [Route("api/[controller]/GetAllAsync")]
        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var envelope = await _permissionQry.GetAllAsync();
            return Ok(envelope);
        }
    }
}