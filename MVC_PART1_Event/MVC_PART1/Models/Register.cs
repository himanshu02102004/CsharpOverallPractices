using System.ComponentModel.DataAnnotations;

namespace MVC_PART1.Models
{
    public class Register
    {
        // Login
        public string UserName { get; set; }
        public string Password { get; set; }

        // Register
        public string Name { get; set; }
        public string Email { get; set; }
        public string Role { get; set; }
    }
}
