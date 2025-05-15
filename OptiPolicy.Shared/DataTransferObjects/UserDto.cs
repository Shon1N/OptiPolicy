namespace OptiPolicy.Shared.DataTransferObjects
{
    public class UserDto
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public string Password { get; set; }
        public int? CreationUserId { get; set; }
        public DateTime CreationDate { get; set; }
        public int? ModificationUserId { get; set; }
        public DateTime? ModificationDate { get; set; }
        public int? DeletionUserId { get; set; }
        public DateTime? DeletionDate { get; set; }
        public virtual IEnumerable<UserGroupDto>? UserGroups { get; set; }
    }
}