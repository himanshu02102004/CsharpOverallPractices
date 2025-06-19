using System.ComponentModel.DataAnnotations;

namespace MVC_PART1.Models
{
    public class User
    {
        public int ID { get; set; }

        [Required]
        public string  Name{ get; set; }

        [Required,EmailAddress]
        public  string Email { get; set; }=string.Empty;

        public ICollection<EventRegistration> Registrations {  get; set; }


    }
}
