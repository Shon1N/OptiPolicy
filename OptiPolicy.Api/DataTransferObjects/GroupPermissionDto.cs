namespace OptiPolicy.Api.DataTransferObjects
{
    public class GroupPermissionDto
    {
        public int Id { get; set; }
        public int GroupId { get; set; }
        public int PermissionId { get; set; }
        public GroupDto Group { get; set; }
        public PermissionDto Permission { get; set; }
    }
}