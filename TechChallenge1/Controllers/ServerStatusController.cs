using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TechChallenge1.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ServerStatusController : ControllerBase
    {
        private readonly ApiContext _context;

        public ServerStatusController(ApiContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IEnumerable<Server> Get()
        {
            var servrs = _context.Servers;
            return servrs;
        }
    }
}
