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
        private OrderProcessorContext _context;

        //ROUTE: api/data
        public DataController(IHostingEnvironment hosting, OrderProcessorContext context)
        {
            _hosting = hosting;
            _context = context;
        }

        //POST: Add data to Database
        //api/data/seed/{id}
        [HttpPost("seed/{id}")]
        public async Task<IActionResult> SeedDatabase(int id)
        {
            if (id == 1)
            {
                string path = _hosting.ContentRootPath;
                string json = await System.IO.File.ReadAllTextAsync(path + "/DataJSON/countries.json");
                var countries = JsonConvert.DeserializeObject<IEnumerable<Country>>(json);
                if (countries != null)
                {
                    foreach (var country in countries)
                    {
                        await _context.Countries.AddAsync(country);
                    }
                    await _context.SaveChangesAsync();
                }
                return Ok("done");
            }
            return Ok("Nothing changed");
        }

        //POST: Create order in database
        //api/data/order/create
        [HttpPost("order/create")]
        public async Task<IActionResult> CreateOrder(string orderJson)
        {
            //Not implemented yet
            return Ok(); //Return Created() <<<
        }
    }
}