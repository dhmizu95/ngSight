using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using ngSightAPI.Models;

namespace ngSightAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomersController : ControllerBase
    {
        private readonly ApiContext _context;

        public CustomersController(ApiContext context)
        {
            _context = context;
        }

        // GET api/customers
        [HttpGet]
        public IActionResult Get()
        {
            var data = _context.Customers.OrderBy(c => c.Id);

            return Ok(data);
        }

        // GET api/customers/5
        [HttpGet("{id}", Name = "GetCustomer")]
        public IActionResult Get(int id)
        {
            var customer = _context.Customers.Find(id);

            return Ok(customer);
        }

        // POST api/customers
        [HttpPost]
        public IActionResult Post([FromBody] Customer customer)
        {
            if (customer == null)
            {
                return BadRequest();
            }

            _context.Customers.Add(customer);
            _context.SaveChanges();

            return CreatedAtRoute("GetCustomer", new {id = customer.Id}, customer);
        }
    }
}
