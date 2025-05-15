using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OptiPolicy.Api.Data;
using OptiPolicy.Api.Data.Interfaces;
using OptiPolicy.Shared.DataTransferObjects;
using OptiPolicy.Api.Entities;
using OptiPolicy.Api.Services.Interfaces;

namespace OptiPolicy.Api.Services
{
    public class GroupPermissionService : IGroupPermissionService
    {
        private readonly IAppDbContext _appDbContext;
        private readonly IMapper _mapper;

        public GroupPermissionService(IAppDbContext appDbContext, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
        }

        public async Task<GroupPermissionDto> CreateAsync(GroupPermissionDto permission)
        {
            var corePermission = _mapper.Map<GroupPermission>(permission);
            _appDbContext.GroupPermissions.Add(corePermission);
            await _appDbContext.SaveChangesAsynchronously();
            return _mapper.Map<GroupPermissionDto>(corePermission);
        }

        public async Task<IEnumerable<GroupPermissionDto>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<GroupPermissionDto>>(await _appDbContext.GroupPermissions.AsNoTracking().ToListAsync());
        }

        public async Task<GroupPermissionDto> GetByIdAsync(int groupPermissionId)
        {
            return _mapper.Map<GroupPermissionDto>(await _appDbContext.GroupPermissions.AsNoTracking().FirstOrDefaultAsync(x => x.Id == groupPermissionId));
        }
    }
}