using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using OrderProcessor.API.Data;
using OrderProcessor.API.Models;

namespace OrderProcessor.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DataController : ControllerBase
    {
        private readonly IHostingEnvironment _hosting;
        private readonly OrderProcessorContext _context;

        //ROUTE: api/data
        public DataController(IHostingEnvironment hosting)
        {
            _hosting = hosting;
        }


        //POST: Add data to Database
        //api/data/seed/{id}
        [HttpPost("/seed/{id}")]
        public async Task<IActionResult> SeedDatabase(int? id)
        {
            
            if (id == null)
                return NotFound();

            if (id == 1)
            {
                string path = _hosting.ContentRootPath;
                string json = System.IO.File.ReadAllText(path + "/DataJSON/users.json");
                var users = JsonConvert.DeserializeObject<IEnumerable<User>>(json);
                if (users != null)
                {
                    foreach(var user in users)
                    {
                        _context.Users.Add(user);
                    }
                    _context.SaveChanges();
                }
            }
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