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
                return Ok("done countries");
            }

            if (id == 2)
            {
                string path = _hosting.ContentRootPath;
                string json = await System.IO.File.ReadAllTextAsync(path + "/DataJSON/currencies.json");
                var currencies = JsonConvert.DeserializeObject<IEnumerable<Currency>>(json);
                if (currencies != null)
                {
                    foreach (var currency in currencies)
                    {
                        await _context.Currencies.AddAsync(currency);
                    }
                    await _context.SaveChangesAsync();
                }
                return Ok("done currencies");
            }

            if (id == 3)
            {
                string path = _hosting.ContentRootPath;
                string json = await System.IO.File.ReadAllTextAsync(path + "/DataJSON/products.json");
                var products = JsonConvert.DeserializeObject<IEnumerable<Product>>(json);
                if (products != null)
                {
                    foreach (var product in products)
                    {
                        await _context.Products.AddAsync(product);
                    }
                    await _context.SaveChangesAsync();
                }
                return Ok("done products");
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