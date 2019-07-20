using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ngSightAPI.Helpers;
using ngSightAPI.Models;

namespace ngSightAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private readonly ApiContext _context;

        public OrdersController(ApiContext context)
        {
            _context = context;
        }

        // GET api/orders
        [HttpGet("{pageIndex}/{pageSize}")]
        public IActionResult Get(int pageIndex, int pageSize)
        {
            var data = _context.Orders
                .Include(o => o.Customer)
                .OrderByDescending(c => c.Placed);

            var page = new PaginatedResponse<Order>(data, pageIndex, pageSize);

            var totalCount = data.Count();
            var totalPage = Math.Ceiling((double) totalCount / pageSize);

            var response = new
            {
                Page = page,
                TotalPages = totalPage
            };

            return Ok(response);
        }

        // GET api/orders
        [HttpGet("ByState")]
        public IActionResult ByState()
        {
            var orders = _context.Orders
                .Include(o => o.Customer)
                .ToList();

            var groupedResult = orders.GroupBy(o => o.Customer.State)
                .ToList()
                .Select(group => new
                {
                    State = group.Key,
                    Total = group.Sum(x => x.Total)
                })
                .OrderByDescending(response => response.State)
                .ToList();

            return Ok(groupedResult);
        }

        // GET api/orders
        [HttpGet("ByCustomer/{n}")]
        public IActionResult ByCustomer(int n)
        {
            var orders = _context.Orders
                .Include(o => o.Customer)
                .ToList();

            var groupedResult = orders.GroupBy(o => o.Customer.State)
                .ToList()
                .Select(group => new
                {
                    State = _context.Customers.Find(group.Key).Name,
                    Total = group.Sum(x => x.Total)
                })
                .OrderByDescending(response => response.State)
                .Take(n)
                .ToList();

            return Ok(groupedResult);
        }

        [HttpGet("GetOrder/{id}")]
        public IActionResult GetOrder(int id)
        {
            var orders = _context.Orders
                .Include(o => o.Customer)
                .First(o => o.Id == id);

            return Ok(orders);
        }
    }
}