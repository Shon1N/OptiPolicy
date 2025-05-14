using OptiPolicy.Api.DataTransferObjects;
using OptiPolicy.Api.Enums;
using OptiPolicy.Api.Services.Interfaces;

namespace OptiPolicy.Api.Features.GroupPermission
{
    public class GroupPermissionQry : IGroupPermissionQry
    {
        private readonly IGroupPermissionService _groupPermissionService;
        public GroupPermissionQry(IGroupPermissionService groupPermissionService)
        {
            _groupPermissionService = groupPermissionService;
        }

        public async Task<Envelope<IEnumerable<GroupPermissionDto>>> GetAllAsync()
        {
            var envelope = new Envelope<IEnumerable<GroupPermissionDto>>();
            try
            {
                envelope.Response = await _groupPermissionService.GetAllAsync();
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

        public async Task<Envelope<GroupPermissionDto>> GetByIdAsync(int groupPermissionId)
        {
            var envelope = new Envelope<GroupPermissionDto>();
            try
            {
                envelope.Response = await _groupPermissionService.GetByIdAsync(groupPermissionId);
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