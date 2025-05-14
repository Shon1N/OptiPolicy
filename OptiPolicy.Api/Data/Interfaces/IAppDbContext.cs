using Microsoft.EntityFrameworkCore;
using OptiPolicy.Api.Entities;

namespace OptiPolicy.Api.Data.Interfaces
{
    public interface IAppDbContext
    {
        DbSet<Group> Groups { get; set; }
        DbSet<GroupPermission> GroupPermissions { get; set; }
        DbSet<Permission> Permissions { get; set; }
        DbSet<User> Users { get; set; }
        DbSet<UserGroup> UserGroups { get; set; }
        Task<int> SaveChangesAsynchronously();
    }
}