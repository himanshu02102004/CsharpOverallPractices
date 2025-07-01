using System.ComponentModel.DataAnnotations;

namespace WebApplication4.Model
{
    public class Customer
    {
        [Key]
        public int CusID { get; set; }
        public string CusName { get; set; }

        public ICollection<Order> Orders { get; set; }
    }

}
