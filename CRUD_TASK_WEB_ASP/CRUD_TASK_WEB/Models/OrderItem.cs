﻿using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CRUDTASK_CODE.Models
{
    public class OrderItem
    {
       [Key]
        public int Id { get; set; }

        [ForeignKey("Order")]
        public int OrderId { get; set; }



        public Order Order { get; set; }

        [ForeignKey("Product")]
        public int PropId { get; set; }
        public Product Product { get; set; }

        public int Quantity { get; set; }
    }
}
 