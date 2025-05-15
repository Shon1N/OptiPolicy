namespace OptiPolicy.Api.Entities
{
    public class Permission
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        //public ICollection<GroupPermission> GroupPermissions { get; set; }
    }
}