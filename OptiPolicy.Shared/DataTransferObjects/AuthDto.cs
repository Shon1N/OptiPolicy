namespace OptiPolicy.Shared.DataTransferObjects
{
    public class AuthDto
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Firstname { get; set; }
        public string Lastname { get; set; }
        public List<string> Permissions { get; set; }
        public string Token { get; set; }
        public DateTime JwtExpiryDate { get; set; }
    }
}