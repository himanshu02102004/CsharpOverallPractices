using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hospital_Management.Model
{
    public class Doctor
    {
        [Key]
        public int Doctor_Id { get; set; }
       public string Doctor_Name { get; set; }
        public string Doctor_Description { get; set; }
        public string Doctor_specialization { get; set; }
      

        public int availability_slot { get; set; }

        [ForeignKey(nameof(Doctor_Id))]
        public int Department_Id { get; set; }
        public Department Department { get; set; }

    }
}
