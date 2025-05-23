﻿using OptiPolicy.Shared.DataTransferObjects;
using OptiPolicy.Shared.Enums;
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

        public async Task<Envelope<GroupPermissionDto>> GetByIdAsync(int groupPermissionId)
        {
            var envelope = new Envelope<GroupPermissionDto>();
            try
            {
                envelope.Response = await _groupPermissionService.GetByIdAsync(groupPermissionId);
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