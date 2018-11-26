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

            if (id == 4)
            {
                string path = _hosting.ContentRootPath;
                string json = await System.IO.File.ReadAllTextAsync(path + "/DataJSON/users.json");
                var users = JsonConvert.DeserializeObject<IEnumerable<User>>(json);
                if (users != null)
                {
                    foreach (var user in users)
                    {
                        await _context.Users.AddAsync(user);
                    }
                    await _context.SaveChangesAsync();
                }
                return Ok("done users");
            }

            if (id == 5)
            {
                string path = _hosting.ContentRootPath;
                string json = await System.IO.File.ReadAllTextAsync(path + "/DataJSON/addresses.json");
                var addresses = JsonConvert.DeserializeObject<IEnumerable<Address>>(json);
                if (addresses != null)
                {
                    foreach (var address in addresses)
                    {
                        await _context.Addresses.AddAsync(address);
                    }
                    await _context.SaveChangesAsync();
                }
                return Ok("done addresses");
            }
            return Ok("Nothing changed");
        }

        //POST: Create order in database
        //api/data/order/create
        [HttpPost("order/create")]
        public async Task<IActionResult> CreateOrder([FromBody] Cart cart)
        {
            if (cart != null)
            {
                Order order = new Order();
                order.UserId = cart.UserId;
                await _context.Orders.AddAsync(order);

                foreach (var line in cart.Lines)
                {
                    OrderProduct op = new OrderProduct();
                    op.OrderId = order.OrderId;
                    op.ProductId = line.ProductId;
                    op.Quantity = line.Quantity;
                    await _context.OrderProducts.AddAsync(op);
                }

                await _context.SaveChangesAsync();
                return Ok("order added to database");
            }

            return Ok("nothing changed!");
        }
    }
}