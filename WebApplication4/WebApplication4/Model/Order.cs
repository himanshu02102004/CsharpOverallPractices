namespace WebApplication4.Model
{
    public class Order
    {
        public int Id { get; set; }
        public string OrderNumber { get; set; }
        public int CustomerId { get; set; }
        Customer Customer { get; set; } 
    }
}
