using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ngSightAPI.Helpers;
using ngSightAPI.Models;

namespace ngSightAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServersController : ControllerBase
    {
        private readonly ApiContext _context;

        public ServersController(ApiContext context)
        {
            _context = context;
        }

        // GET: api/Servers
        [HttpGet]
        public IActionResult Get()
        {
            var response = _context.Servers.OrderBy(s => s.Id).ToList();
            return Ok(response);
        }

        // GET: api/Servers/5
        [HttpGet("{id}", Name = "GetServer")]
        public IActionResult Get(int id)
        {
            var response = _context.Servers.Find(id);
            return Ok(response);
        }

        // GET: api/Servers/5
        [HttpPut("{id}")]
        public IActionResult Message(int id, [FromBody] ServerMessage message)
        {
            var server = _context.Servers.Find(id);

            if (server == null)
            {
                return NotFound();
            }

            if (message.Payload == "activate")
            {
                server.IsOnline = true;
            }

            if (message.Payload == "deactivate")
            {
                server.IsOnline = false;
            }

            _context.SaveChanges();
            return new NoContentResult();
        }

    }
}
