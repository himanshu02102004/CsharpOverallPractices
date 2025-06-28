namespace WebApplication3.Model
{
    public class Order
    {

        public int Orderid { get; set; }

        public string Orderdate { get; set; }
        Customer Customer { get; set; }
        public int CustomerId { get; set; }

    }
}
