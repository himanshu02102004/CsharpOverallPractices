using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Globalization;

namespace CRUD_CODEFIRST.Models
{
    public class User

    {

        [Key]
        public int Id { get; set; }

        [Column("UserName",TypeName ="varchar(100)")]


        [Required]
        public string  Name { get; set; }

        [Required]
        public string Email { get; set; }
        [Column("UserGender",TypeName ="varchar(20)")]



        [Required]
        public string  Gender { get; set; }


        [Required]
        public int ? phoneno { get; set; }

    }
}
