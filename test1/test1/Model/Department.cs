using System.ComponentModel.DataAnnotations;

namespace test1.Model
{
    public class Department
    {
        [Key]
        public int Depart_Id { get; set; }
        public string Depart_Name { get; set; } = string.Empty;
    }
}
