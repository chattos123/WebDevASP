namespace WebApplicationTest.Models
{
    public class UserProfile
    {
        public required string Username { get; set; }
        public required string Password { get; set; } // simple demo password
        public required string Role { get; set; }
    }
}
