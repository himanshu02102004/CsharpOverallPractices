using CRUDTASK_CODE.DTOs;
using CRUDTASK_CODE.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
        public async Task<ActionResult<List<Order>>> GetOrders()
        {
            var orders = await productContext.Orders
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Product)
                .ToListAsync();

            return Ok(orders);
        }

        [HttpGet("GetOrderById/{id}")]
        public async Task<ActionResult<Order>> GetOrderById(int id)
        {
            var order = await productContext.Orders
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Product)
                .FirstOrDefaultAsync(x => x.OrderId == id);

            if (order == null)
                return NotFound("Order not found");

            return Ok(order);
        }

        [HttpPost("AddOrder")]
        public async Task<IActionResult> AddOrder([FromBody] OrderDTO orderDto)
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

            await productContext.Orders.AddAsync(order);
            await productContext.SaveChangesAsync();

            return Ok("Order Added Successfully");
        }
    }
}
