using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace OrderProcessor.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        //ROUTE: api/data

        //POST: Add data to Database
        //api/data/seed/{id}
        [HttpPost("/seed/{id}")]
        public async Task<IActionResult> SeedDatabase(int id)
        {
            //Not implemented yet
            return Ok();
        }

        //POST: Create order in database
        //api/data/order/create
        [HttpPost("/order/create")]
        public async Task<IActionResult> CreateOrder(string orderJson)
        {
            //Not implemented yet
            return Ok(); //Return Created() <<<
        }
    }
}