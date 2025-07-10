namespace Hospital_Management.Model
{
    public class Prescription
    {



        public int Id { get; set; }
        public int Patient_id { get; set; }
        public string Notes { get; set; }

        public DateTime ? FollowUpdate { get; set; }


        public int Doctor_Id { get; set; }





        public Doctor doctor { get; set; }
        public Patient Patient { get; set; }

    }
}
