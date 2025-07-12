using System.ComponentModel.DataAnnotations;

namespace test1.Model
{
    public class Doctor
    {
        [Key]
        public int Doc_Id { get; set; }
        public string Doc_Name { get; set; } = string.Empty;
    }
}
