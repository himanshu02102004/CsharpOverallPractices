using System.ComponentModel.DataAnnotations;

namespace task.Model
{
    public class Customer
    {
        [Key]
        public string name { get; set; }
        public string age { get; set; }
    }
}
