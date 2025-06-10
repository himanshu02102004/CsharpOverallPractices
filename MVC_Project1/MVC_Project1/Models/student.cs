using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MVC_Project1.Models
{
    public class student
    {
        [Key]
        public int ID { get; set; }

        [Column("StudentName",TypeName ="varchar(100)")]
        public String Name { get; set; }
        [Column("StudentGender", TypeName = "varchar(100)")]
        public string  gender { get; set; }

        public int  Age { get; set; }
        public int standard { get; set; }
    }
}
