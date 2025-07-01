namespace reviewtask1.Model
{
    public class Customer
    {
        public int CustomerID { get; set; }
        public string CustomerName { get; set; }
        public string CustomerEmail { get; set; }

        public ICollection<Order> Orders { get; set; }


    }
}
