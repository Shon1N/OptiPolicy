using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OptiPolicy.Api.Data.Interfaces;
using OptiPolicy.Shared.DataTransferObjects;
using OptiPolicy.Api.Entities;
using OptiPolicy.Api.Services.Interfaces;

namespace OptiPolicy.Api.Services
{
    public class GroupService : IGroupService
    {
        private readonly IAppDbContext _appDbContext;
        private readonly IMapper _mapper;

        public GroupService(IAppDbContext appDbContext, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
        }

        public async Task<GroupDto> CreateAsync(GroupDto group)
        {
            var coreGroup = _mapper.Map<Group>(group);
            _appDbContext.Groups.Add(coreGroup);
            await _appDbContext.SaveChangesAsynchronously();
            return _mapper.Map<GroupDto>(coreGroup);
        }

        public async Task<IEnumerable<GroupDto>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<GroupDto>>(await _appDbContext.Groups.AsNoTracking().ToListAsync());
        }

        public async Task<GroupDto> GetByIdAsync(int groupId)
        {
            return _mapper.Map<GroupDto>(await _appDbContext.Groups.AsNoTracking().FirstOrDefaultAsync(x => x.Id == groupId));
        }
    }
}