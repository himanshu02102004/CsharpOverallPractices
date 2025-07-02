using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using reviewtask1.DTO;
using reviewtask1.Model;
using reviewtask1.Services;
using System.Runtime.CompilerServices;

namespace reviewtask1.Controllers
{

    [ApiController]
    [Route("api/[controller]")]
    public class CustomerController : ControllerBase
    {

        private readonly ICustomer _customerService;
        public CustomerController(ICustomer customerService)
        {
            _customerService = customerService;
        }


        [HttpPost("add-update-category")]
        public async Task<IActionResult> AddupdateCategory( Category cat)
        {
            if (cat == null)
            {
                return BadRequest("Category cannot be null");
            }
            var result = await _customerService.AddandupdateCategory(cat);
            return Ok(result);
        }



        [HttpPost("add-customer")]
        public async Task<IActionResult> Addupdatecustomer(Customer cus)
        {
            if(cus == null)
            {
                return BadRequest("customer is not null");
            }
            var result = await _customerService.AddandupdateCustomer(cus);
            return Ok(result);

        }



        [HttpPost("add-order")]
        public async Task<IActionResult> AddOrder(Order order)
        {
            if(order == null)
            {
                return  BadRequest("Order cannot be null");

            }
            var result = await _customerService.AddOrder(order);
            return Ok(result);
        }


        [HttpPost("add-product")]
        public async Task<IActionResult> AddProduct(Product prod)
        {
            if (prod == null)
            {
                return BadRequest("Product cannot be null");
            }
            var result = await _customerService.AddProduct(prod);
            return Ok(result);
        }




    } }
