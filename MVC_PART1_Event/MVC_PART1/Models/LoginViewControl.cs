
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
namespace MVC_PART1.Models

{

    [NotMapped]
    public class LoginViewControl
    {


        [Required(ErrorMessage = "User Name is required")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "Password is required")]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress(ErrorMessage = "Invalid email address")]
        public string Email { get; set; }


        [Required]
        public string Role { get;  set; }
        public int UserId { get;  set; }
        

        // for new user
        public string Name { get; set; }
    }
}
