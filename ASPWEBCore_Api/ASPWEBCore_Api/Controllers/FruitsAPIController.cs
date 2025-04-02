using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ASPWEBCore_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FruitsAPIController : ControllerBase
    {

        public List<string> fruits = new List<string>
        {
              "banana",
              "grapes",
              "mango",
              "chery",
              "kella"
        };

        [HttpGet]
        public List<string> GetFruits()
        {
            return fruits;
        }

        [HttpGet("{id}")]
        public string GetFruitsByIndex(int id)
        {
            return fruits.ElementAt(id);
        }
    }
}
