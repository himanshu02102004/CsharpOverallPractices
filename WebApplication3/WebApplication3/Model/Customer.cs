namespace WebApplication3.Model
{
    public class Customer
    {

        public int Id { get; set; }
        public string Name { get; set; }
      
        // Navigation property for related orders
        public ICollection<Order> Orders { get; set; } = new List<Order>();

        // Additional properties can be added as needed
    }
}
