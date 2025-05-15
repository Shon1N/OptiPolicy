namespace OptiPolicy.Shared.DataTransferObjects
{
    public class GroupPermissionDto
    {
        public int Id { get; set; }
        public int GroupId { get; set; }
        public int PermissionId { get; set; }
        //public virtual GroupDto Group { get; set; }
        public virtual PermissionDto Permission { get; set; }
    }
}