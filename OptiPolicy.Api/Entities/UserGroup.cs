namespace OptiPolicy.Api.Entities
{
    public class UserGroup
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public int GroupId { get; set; }
        public int? CreationUserId { get; set; }
        public DateTime CreationDate { get; set; }
        public int? DeletionUserId { get; set; }
        public DateTime? DeletionDate { get; set; }
        //public User User { get; set; }
        public Group Group { get; set; }
    }
}