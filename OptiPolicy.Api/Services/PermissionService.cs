using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OptiPolicy.Api.Data.Interfaces;
using OptiPolicy.Api.DataTransferObjects;
using OptiPolicy.Api.Entities;
using OptiPolicy.Api.Services.Interfaces;

namespace OptiPolicy.Api.Services
{
    public class PermissionService : IPermissionService
    {
        private readonly IAppDbContext _appDbContext;
        private readonly IMapper _mapper;

        public PermissionService(IAppDbContext appDbContext, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
        }

        public async Task<PermissionDto> CreateAsync(PermissionDto permission)
        {
            var corePermission = _mapper.Map<Permission>(permission);
            _appDbContext.Permissions.Add(corePermission);
            await _appDbContext.SaveChangesAsynchronously();
            return _mapper.Map<PermissionDto>(corePermission);
        }

        public async Task<IEnumerable<PermissionDto>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<PermissionDto>>(await _appDbContext.Permissions.AsNoTracking().ToListAsync());
        }

        public async Task<PermissionDto> GetByIdAsync(int permissionId)
        {
            return _mapper.Map<PermissionDto>(await _appDbContext.Permissions.AsNoTracking().FirstOrDefaultAsync(x => x.Id == permissionId));
        }
    }
}