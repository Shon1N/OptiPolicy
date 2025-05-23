﻿using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OptiPolicy.Api.Data.Interfaces;
using OptiPolicy.Shared.DataTransferObjects;
using OptiPolicy.Api.Entities;
using OptiPolicy.Api.Services.Interfaces;

namespace OptiPolicy.Api.Services
{
    public class UserService : IUserService
    {
        private readonly IAppDbContext _appDbContext;
        private readonly IMapper _mapper;

        public UserService(IAppDbContext appDbContext, IMapper mapper)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
        }

        public async Task<UserDto> CreateAsync(UserDto user)
        {
            var coreUser = _mapper.Map<User>(user);
            _appDbContext.Users.Add(coreUser);
            await _appDbContext.SaveChangesAsynchronously();
            return _mapper.Map<UserDto>(coreUser);
        }

        public async Task<UserDto> DeleteAsync(UserDto user)
        {
            var coreUser = await _appDbContext.Users.FirstOrDefaultAsync(x => x.Id == user.Id);
            coreUser.DeletionUserId = user.DeletionUserId;
            coreUser.DeletionDate = user.DeletionDate;
            coreUser.Username = user.Username;
            await _appDbContext.SaveChangesAsynchronously();
            return _mapper.Map<UserDto>(coreUser);
        }

        public async Task<IEnumerable<UserDto>> GetAllAsync()
        {
            return _mapper.Map<IEnumerable<UserDto>>(await _appDbContext.Users.Include(x => x.UserGroups.Where(x => x.DeletionDate == null)).Where(x => x.DeletionDate == null).AsNoTracking().ToListAsync());
        }

        public async Task<UserDto> GetByIdAsync(int userId)
        {
            return _mapper.Map<UserDto>(await _appDbContext.Users.Include(x => x.UserGroups.Where(x => x.DeletionDate == null)).AsNoTracking().FirstOrDefaultAsync(x => x.Id == userId));
        }

        public async Task<int> GetUserCountAsync()
        {
            return await _appDbContext.Users.Where(x => x.DeletionDate == null).AsNoTracking().CountAsync();
        }

        public async Task<int> GetUserCountByGroupIdAsync(int groupId)
        {
            return await _appDbContext.Users
                .Where(x => x.UserGroups.Any(x => x.DeletionDate == null && x.GroupId == groupId))
                .Where(x => x.DeletionDate == null)
                .AsNoTracking()
                .CountAsync();
        }

        public async Task<UserDto> UpdateAsync(UserDto user)
        {
            var coreUser = await _appDbContext.Users.FirstOrDefaultAsync(x => x.Id == user.Id);
            coreUser.Username = user.Username;
            coreUser.Firstname = user.Firstname;
            coreUser.Lastname = user.Lastname;
            coreUser.ModificationUserId = user.ModificationUserId;
            coreUser.ModificationDate = user.ModificationDate;
            await _appDbContext.SaveChangesAsynchronously();
            return _mapper.Map<UserDto>(coreUser);
        }
    }
}