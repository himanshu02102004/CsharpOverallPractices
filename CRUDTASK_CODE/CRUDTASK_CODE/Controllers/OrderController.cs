using CRUDTASK_CODE.DTOs;
using CRUDTASK_CODE.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRUDTASK_CODE.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {
        private readonly ProductContext productContext;
        public OrderController(ProductContext productContext)
        {
            this.productContext = productContext;
        }

        [HttpGet("GetOrders")]
        public List<Order> GetOrders()
        {
            return productContext.Orders
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Product)
                .ToList();
        }

        [HttpGet("GetOrderById/{id}")]
        public ActionResult<Order> GetOrderById(int id)
        {
            var order = productContext.Orders
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Product)
                .FirstOrDefault(x => x.OrderId == id);

            if (order == null) return NotFound("Order not found");
            return Ok(order);
        }



        [HttpPost("AddOrder")]
        public IActionResult AddOrder([FromBody] OrderDTO orderDto)
        {
            var order = new Order
            {
                CustomerName = orderDto.CustomerName,
                OrderItems = orderDto.OrderItems.Select(item => new OrderItem
                {
                    PropId = item.ProductId,
                    Quantity = item.Quantity
                }).ToList()
            };

            productContext.Orders.Add(order);
            productContext.SaveChanges();
            return Ok("Order Added Successfully");
        }

    }
}

