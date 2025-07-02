using System.Text.Json.Serialization;

namespace reviewtask1.Model
{
    public class Category
    {

        public int CategoryID { get; set; }
        public string CategoryName { get; set; }

        [JsonIgnore]
        public ICollection<Product>? Products { get; set; }



    }
}
