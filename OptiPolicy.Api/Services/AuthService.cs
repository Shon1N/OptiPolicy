using AutoMapper;
using Microsoft.EntityFrameworkCore;
using OptiPolicy.Api.Authorization.Services.Interfaces;
using OptiPolicy.Api.Data.Interfaces;
using OptiPolicy.Shared.DataTransferObjects;
using OptiPolicy.Api.Services.Interfaces;

namespace OptiPolicy.Api.Services
{
    public class AuthService : IAuthService
    {

        private readonly IAppDbContext _appDbContext;
        private readonly IMapper _mapper;
        private readonly IJWTTokenService _tokenService;
        public AuthService(IAppDbContext appDbContext, IMapper mapper, IJWTTokenService tokenService)
        {
            _appDbContext = appDbContext;
            _mapper = mapper;
            _tokenService = tokenService;
        }

        public async Task<AuthDto> LoginAsync(LoginDto loginDto)
        {
            var expiryDate = DateTime.UtcNow.AddDays(1);
            var user = _mapper.Map<UserDto>(await _appDbContext.Users
                .Include(x => x.UserGroups.Where(x => x.DeletionDate == null))                
                .ThenInclude(x => x.Group)
                .ThenInclude(x => x.GroupPermissions)
                .ThenInclude(x => x.Permission)
                .FirstOrDefaultAsync(x => x.Username == loginDto.Username && x.Password == loginDto.Password && x.DeletionDate == null));
            if(user == null)
            {
                return null;
            }
            var authDto = new AuthDto
            {
                UserId = user.Id,
                Username = user.Username,
                Firstname = user.Firstname,
                Lastname = user.Lastname,
                Permissions = user.UserGroups.SelectMany(x => x.Group.GroupPermissions.Select(x => x.Permission.Name)).ToList(),
                Token = await _tokenService.GenerateJwtToken(user, expiryDate),
                JwtExpiryDate = expiryDate
            };

            return authDto;
        }

        public Task<string> LogOutAsync(int userId)
        {
            throw new NotImplementedException();
        }
    }
}