﻿using OptiPolicy.Shared.DataTransferObjects;
using OptiPolicy.Shared.Enums;
using OptiPolicy.Api.Services;
using OptiPolicy.Api.Services.Interfaces;

namespace OptiPolicy.Api.Features.UserGroup
{
    public class UserGroupQry : IUserGroupQry
    {
        private IUserGroupService _userGroupService;
        public UserGroupQry(IUserGroupService userGroupService)
        {
            _userGroupService = userGroupService;
        }

        public async Task<Envelope<IEnumerable<UserGroupDto>>> GetAllAsync()
        {
            var envelope = new Envelope<IEnumerable<UserGroupDto>>();
            try
            {
                envelope.Response = await _userGroupService.GetAllAsync();
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

        public async Task<Envelope<UserGroupDto>> GetByIdAsync(int userGroupId)
        {
            var envelope = new Envelope<UserGroupDto>();
            try
            {
                envelope.Response = await _userGroupService.GetByIdAsync(userGroupId);
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