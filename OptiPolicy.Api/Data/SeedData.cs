using OptiPolicy.Shared.DataTransferObjects;
using OptiPolicy.Shared.Enums;

namespace OptiPolicy.Api.Data
{
    public static class SeedData
    {
        //Premissions
        public static List<PermissionDto> Permissions = new()
        {
            new(){Name = nameof(PermissionEnum.Create), Description = nameof(PermissionEnum.Create)},
            new(){Name = nameof(PermissionEnum.Read), Description = nameof(PermissionEnum.Read)},
            new(){Name = nameof(PermissionEnum.Update), Description = nameof(PermissionEnum.Update)},
            new(){Name = nameof(PermissionEnum.Delete), Description = nameof(PermissionEnum.Delete)}
        };

        //Groups
        public static List<GroupDto> Groups = new()
        {
            new(){Name = nameof(GroupEnum.User), Description = nameof(GroupEnum.User)},
            new(){Name = nameof(GroupEnum.Admin), Description = nameof(GroupEnum.Admin)}
        };

        //Group Permissions
        public static List<GroupPermissionDto> GroupPermissions = new()
        {
            new(){GroupId = (int)GroupEnum.User, PermissionId = (int)PermissionEnum.Read},
            new(){GroupId = (int)GroupEnum.Admin, PermissionId = (int)PermissionEnum.Create},
            new(){GroupId = (int)GroupEnum.Admin, PermissionId = (int)PermissionEnum.Read},
            new(){GroupId = (int)GroupEnum.Admin, PermissionId = (int)PermissionEnum.Update},
            new(){GroupId = (int)GroupEnum.Admin, PermissionId = (int)PermissionEnum.Delete}
        };

        //Users
        public static UserDto AdminUser = new()
        {
            Username = "Admin",
            Firstname = "Origin",
            Lastname = "Pro",
            Password = "12345",
            CreationDate = DateTime.UtcNow
        };

        //User Groups
        public static List<UserGroupDto> UserGroups = new()
        {
            new(){UserId = 1, GroupId = (int)GroupEnum.User, CreationDate = DateTime.UtcNow},
            new(){UserId = 1, GroupId = (int)GroupEnum.Admin, CreationDate = DateTime.UtcNow}
        };
    }
}
