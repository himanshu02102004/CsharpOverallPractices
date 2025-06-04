using CRUD_TASK_WEB.Models;
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
        private readonly ApiContext productContext;
        public OrderController(ApiContext productContext)
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




        [HttpPost("FilterOrders")]
        public async Task<ActionResult<List<Order>>> FilterOrders([FromBody] OrderfilterDTO filter)
        {
            var query = productContext.Orders
                .Include(o => o.OrderItems)
                .ThenInclude(oi => oi.Product)
                .AsQueryable();

            if (!string.IsNullOrEmpty(filter.CustomerName))
            {
                query = query.Where(o => o.CustomerName.Contains(filter.CustomerName));
            }

            if (filter.MinTotal.HasValue)
            {
                query = query.Where(o =>
                    o.OrderItems.Sum(i => i.Quantity * i.Product.PropPrice) >= filter.MinTotal.Value);
            }

            var result = await query.ToListAsync();
            return Ok(result);
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
            foreach (var res in orderDto.OrderItems)
            {
                if(res.Quantity < 1)
                {
                    return BadRequest("Quantity at least 1");
                }
            }
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





