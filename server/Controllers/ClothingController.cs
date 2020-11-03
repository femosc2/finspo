using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using server.Data;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClothingController : ControllerBase
    {
        private FinspoDbContext _finspoDbContext;

        public ClothingController(FinspoDbContext finspoDbContext)
        {
            _finspoDbContext = finspoDbContext;
        }
        // GET: api/<ClothingController>
        [HttpGet]
        public IActionResult Get()
        {
            return Ok(_finspoDbContext.Clothing);
        }

        // GET api/<ClothingController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }
    }
}
