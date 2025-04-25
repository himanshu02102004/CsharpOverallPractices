
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace CRUDTASK_CODE.Models
{
    public class Users
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }

        
        public string ContactNo { get; set; }

        public string emailaddress { get; set; }

        public string password { get; set; }


        // for soft delete concept
        [JsonIgnore]
        public bool IsDeleted { get; set; }

    }
}
