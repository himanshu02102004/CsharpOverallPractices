namespace Hospital_Management.Model
{
    public class Patient
    {

        public int Patient_id { get; set; }
        public string Patient_name { get; set; }
        public int patient_phoneNo { get; set; }

        public string Patient_description { get; set; } = string.Empty;

    }
}