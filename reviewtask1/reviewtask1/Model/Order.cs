using System.Text.Json.Serialization;

namespace reviewtask1.Model
{
    public class Order
    {

        public int OrderID { get; set; }

        public DateTime OrderDate { get; set; }
        public int CustomerID { get; set; }
        public int ProductID { get; set; }
        [JsonIgnore]
        public Customer ? Customer { get; set; }

        [JsonIgnore]
       public  Product ? Products { get; set; }
      
    }
}
