using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OptiPolicy.Api.Data.Interfaces;
using OptiPolicy.Shared.DataTransferObjects;
using OptiPolicy.Api.Entities;
using OptiPolicy.Api.Services.Interfaces;

namespace OptiPolicy.Api.Services
{
    public class UserGroupService : IUserGroupService
    {
        private readonly IAppDbContext _appDbContext;
        private readonly IMapper _mapper;

        public UserGroupService(IAppDbContext appDbContext, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
        }

        public async Task<UserGroupDto> CreateAsync(UserGroupDto userGroup)
        {
            var coreGroup = _mapper.Map<UserGroup>(userGroup);
            _appDbContext.UserGroups.Add(coreGroup);
            await _appDbContext.SaveChangesAsynchronously();
            return _mapper.Map<UserGroupDto>(coreGroup);
        }

        public async Task<UserGroupDto> DeleteAsync(UserGroupDto userGroup)
        {
            var coreUserGroup = await _appDbContext.UserGroups.FirstOrDefaultAsync(x => x.Id == userGroup.Id);
            coreUserGroup.DeletionUserId = userGroup.DeletionUserId;
            coreUserGroup.DeletionDate = userGroup.DeletionDate;
            await _appDbContext.SaveChangesAsynchronously();
            return _mapper.Map<UserGroupDto>(coreUserGroup);
        }

        public async Task<IEnumerable<UserGroupDto>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<UserGroupDto>>(await _appDbContext.UserGroups.Where(x => x.DeletionDate == null).AsNoTracking().ToListAsync());
        }

        public async Task<UserGroupDto> GetByIdAsync(int userGroupId)
        {
            return _mapper.Map<UserGroupDto>(await _appDbContext.UserGroups.AsNoTracking().FirstOrDefaultAsync(x => x.Id == userGroupId));
        }
    }
}