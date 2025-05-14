using Microsoft.AspNetCore.Http;
using OptiPolicy.Api.DataTransferObjects;
using OptiPolicy.Api.Enums;
using OptiPolicy.Api.Services.Interfaces;

namespace OptiPolicy.Api.Features.Group
{
    public class GroupQry : IGroupQry
    {
        private readonly IGroupService _groupService;
        public GroupQry(IGroupService groupService)
        {
            _groupService = groupService;
        }

        public async Task<Envelope<IEnumerable<GroupDto>>> GetAllAsync()
        {
            var envelope = new Envelope<IEnumerable<GroupDto>>();
            try
            {
                envelope.Response = await _groupService.GetAllAsync();
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

        public async Task<Envelope<GroupDto>> GetByIdAsync(int groupId)
        {
            var envelope = new Envelope<GroupDto>();
            try
            {
                envelope.Response = await _groupService.GetByIdAsync(groupId);
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