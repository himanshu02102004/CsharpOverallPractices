using System.Text.Json.Serialization;

namespace reviewtask1.Model
{
    public class Product
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public string ProductPrice { get; set; }

        public int categoryID  { get; set; }
        [JsonIgnore]
        public ICollection<Order>? orders { get; set; }  
        [JsonIgnore]
        public Category ?  category { get; set; }



    }
}
