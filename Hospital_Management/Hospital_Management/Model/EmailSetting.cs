using System.ComponentModel.DataAnnotations;

namespace Hospital_Management.Model
{
    public class EmailSetting
    {
        [Key]
        public string FromEmail { get; set; }
        public string SmptHost { get; set; }
        public int  SmptPort { get; set; }
        public string Username { get; set; }   
        public string Password { get; set; }
    }
}
