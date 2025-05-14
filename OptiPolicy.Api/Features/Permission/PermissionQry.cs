using OptiPolicy.Api.DataTransferObjects;
using OptiPolicy.Api.Enums;
using OptiPolicy.Api.Services;
using OptiPolicy.Api.Services.Interfaces;

namespace OptiPolicy.Api.Features.Permission
{
    public class PermissionQry : IPermissionQry
    {
        private readonly IPermissionService _permissionService;
        public PermissionQry(IPermissionService permissionService)
        {
            _permissionService = permissionService;            
        }

        public async Task<Envelope<IEnumerable<PermissionDto>>> GetAllAsync()
        {
            var envelope = new Envelope<IEnumerable<PermissionDto>>();
            try
            {
                envelope.Response = await _permissionService.GetAllAsync();
                envelope.Result = nameof(StatusDescription.Passed);
                envelope.Message = "Query executed successfully.";
                envelope.StatusCode = (int)StatusCode.Ok;
            }
            catch (Exception ex)
            {
                envelope.Result = nameof(StatusDescription.Failed);
                envelope.Message = $"{ex.Message}";
                envelope.StatusCode = (int)StatusCode.InternalServerError;
            }
            return envelope;
        }

        public async Task<Envelope<PermissionDto>> GetByIdAsync(int groupPermissionId)
        {
            var envelope = new Envelope<PermissionDto>();
            try
            {
                envelope.Response = await _permissionService.GetByIdAsync(groupPermissionId);
                envelope.Result = nameof(StatusDescription.Passed);
                envelope.Message = "Query executed successfully.";
                envelope.StatusCode = (int)StatusCode.Ok;
            }
            catch (Exception ex)
            {
                envelope.Result = nameof(StatusDescription.Failed);
                envelope.Message = $"{ex.Message}";
                envelope.StatusCode = (int)StatusCode.InternalServerError;
            }
            return envelope;
        }
    }
}