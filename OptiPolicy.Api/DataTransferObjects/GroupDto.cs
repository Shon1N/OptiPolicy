namespace OptiPolicy.Api.DataTransferObjects
{
    public class GroupDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public virtual ICollection<UserGroupDto> UserGroups { get; set; }
        public ICollection<GroupPermissionDto> GroupPermissions { get; set; }
    }
}