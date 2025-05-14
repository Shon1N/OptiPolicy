using OptiPolicy.Api.Data;
using OptiPolicy.Api.Services.Interfaces;

namespace OptiPolicy.Api.Services
{
    public class Seed : ISeed
    {
        private readonly IGroupService _groupService;
        private readonly IGroupPermissionService _groupPermissionService;
        private readonly IPermissionService _permissionService;
        private readonly IUserService _userService;
        private readonly IUserGroupService _userGroupService;

        public Seed(IGroupService groupService,
            IGroupPermissionService groupPermissionService,
            IPermissionService permissionService,
            IUserService userService,
            IUserGroupService userGroupService)
        {
            _groupService = groupService;
            _groupPermissionService = groupPermissionService;
            _permissionService = permissionService;
            _userService = userService;
            _userGroupService = userGroupService;
        }

        public void SeedDatabase()
        {
            SeedPermissions();
            SeedGroups();
            SeedGroupPermissions();
            SeedUsers();
            SeedUserGroups();
        }

        public void SeedPermissions()
        {
            var existingRecords = _permissionService.GetAllAsync().Result;
            if (existingRecords.Any())
            {
                return;
            }

            foreach (var record in SeedData.Permissions)
            {
                var result = _permissionService.CreateAsync(record).Result;
            }
        }

        public void SeedGroups()
        {
            var existingRecords = _groupService.GetAllAsync().Result;
            if (existingRecords.Any())
            {
                return;
            }

            foreach (var record in SeedData.Groups)
            {
                var result = _groupService.CreateAsync(record).Result;
            }
        }

        public void SeedGroupPermissions()
        {
            var existingRecords = _groupPermissionService.GetAllAsync().Result;
            if (existingRecords.Any())
            {
                return;
            }

            foreach (var record in SeedData.GroupPermissions)
            {
                var result = _groupPermissionService.CreateAsync(record).Result;
            }
        }

        public void SeedUsers()
        {
            var existingRecords = _userService.GetAllAsync().Result;
            if (existingRecords.Any())
            {
                return;
            }

            var record = SeedData.AdminUser;
            var result = _userService.CreateAsync(record).Result;
        }

        public void SeedUserGroups()
        {
            var existingRecords = _userGroupService.GetAllAsync().Result;
            if (existingRecords.Any())
            {
                return;
            }

            foreach (var record in SeedData.UserGroups)
            {
               var result = _userGroupService.CreateAsync(record).Result;
            }
        }
    }
}