using System.ComponentModel.DataAnnotations;

namespace Exercises.Models
{
    public class User
    {

        [Key]
        public int Id { get; set; }

        public string  names { get; set; }

        public string  ContactNo { get; set; }


    }
}
