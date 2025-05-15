namespace OptiPolicy.Shared.DataTransferObjects
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
        //public virtual UserDto User { get; set; }
        public virtual GroupDto? Group { get; set; }
    }
}