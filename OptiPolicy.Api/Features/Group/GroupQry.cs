using Microsoft.AspNetCore.Http;
using OptiPolicy.Shared.DataTransferObjects;
using OptiPolicy.Shared.Enums;
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

        public async Task<Envelope<GroupDto>> GetByIdAsync(int groupId)
        {
            var envelope = new Envelope<GroupDto>();
            try
            {
                envelope.Response = await _groupService.GetByIdAsync(groupId);
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
    }
}