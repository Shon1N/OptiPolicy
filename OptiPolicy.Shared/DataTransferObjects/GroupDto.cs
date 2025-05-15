namespace OptiPolicy.Shared.DataTransferObjects
{
    public class GroupDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        //public virtual IEnumerable<UserGroupDto> UserGroups { get; set; }
        public virtual IEnumerable<GroupPermissionDto> GroupPermissions { get; set; }
    }
}