using System.ComponentModel.DataAnnotations;

namespace CRUDTASK_CODE.DTOs
{
    public class OrderDTO
    {

        public int OrderId { get; set; }
       public string CustomerName { get; set; }

        [Required]
        [EmailAddress(ErrorMessage = "Invalid Email Address.")]
        public string email { get; set; }
        public List<OrderItemDTO> OrderItems { get; set; }
    }
}

