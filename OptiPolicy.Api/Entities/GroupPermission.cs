namespace OptiPolicy.Api.Entities
{
    public class GroupPermission
    {
        public int Id { get; set; }
        public int GroupId { get; set; }
        public int PermissionId { get; set; }
        public int CreationUserId { get; set; }
        public DateTime CreationDate { get; set; }
        public int? DeletionUserId { get; set; }
        public DateTime? DeletionDate { get; set; }
        public virtual Group Group { get; set; }
        public virtual Permission Permission { get; set; }
    }
}