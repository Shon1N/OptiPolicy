namespace OptiPolicy.Api.DataTransferObjects
{
    public class UserGroupDto
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int GroupId { get; set; }
        public int? CreationUserId { get; set; }
        public DateTime CreationDate { get; set; }
        public int? DeletionUserId { get; set; }
        public DateTime? DeletionDate { get; set; }
        public UserDto User { get; set; }
        public GroupDto Group { get; set; }
    }
}