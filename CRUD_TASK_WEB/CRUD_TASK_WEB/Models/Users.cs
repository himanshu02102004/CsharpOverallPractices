
using System.ComponentModel.DataAnnotations;

namespace CRUDTASK_CODE.Models
{
    public class Users
    {
        [Key]
        public int ID { get; set; }
        public string Name { get; set; }


        public string ContactNo { get; set; }



        // for soft delete concept
        public bool IsDeleted { get; set; }

    }
}
