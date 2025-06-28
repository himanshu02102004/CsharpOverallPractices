namespace reviewtask1.Model
{
    public class Order
    {

        public int OrderID { get; set; }

        public DateTime OrderDate { get; set; }
        public int CustomerID { get; set; }
        public Customer Customer { get; set; }

       
       public ICollection<Product> Products { get; set; }
      
    }
}
