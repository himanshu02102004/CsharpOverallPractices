using System.ComponentModel.DataAnnotations;

namespace exercisescrud.Model
{
    public class User
    {

        [Key]

        public int  Id{ get; set; }

        public string name { get; set; }

        public int phoneno { get; set; }

        public string  username { get; set; }

        public string  password { get; set; }
    }
}
