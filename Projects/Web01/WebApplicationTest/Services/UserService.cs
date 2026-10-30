using WebApplicationTest.Models;

namespace WebApplicationTest.Services
{
    public class UserService
    {
        private readonly List<UserProfile> _users = new List<UserProfile>
        {
            new UserProfile { Username = "admin", Password = "password", Role = "Administrator" },
            new UserProfile { Username = "editor", Password = "password", Role = "Editor" },
            new UserProfile { Username = "viewer", Password = "password", Role = "Viewer" }
        };

        public UserProfile? GetUser(string username, string password)
        {
            // For demo: password is always "password"
            return _users.FirstOrDefault(u => u.Username == username && u.Password == password);
        }
    }
}
