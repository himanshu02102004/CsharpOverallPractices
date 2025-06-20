using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
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

        [ValidateNever] // Skip validation
        public ICollection<EventRegistration> Registrations { get; set; } = new List<EventRegistration>();

    }
}
