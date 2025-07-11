using System.ComponentModel.DataAnnotations;

namespace Hospital_Management.Model
{
    public class Prescription
    {


        [Key]
        public int Id { get; set; }
        public int Patient_id { get; set; }
        public string Notes { get; set; }

        public DateTime ? FollowUpdate { get; set; }


        public int Doctor_Id { get; set; }


        public Doctor Doctor { get; set; }




        public int Appoitment_Id { get; set; }
        public Appointment appointment { get; set; }


        public Doctor doctor { get; set; }
        public Patient Patient { get; set; }

    }
}
