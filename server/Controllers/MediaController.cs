using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using server.Data;
using server.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MediaController : ControllerBase
    {
        private FinspoDbContext _finspoDbContext;

        public MediaController(FinspoDbContext finspoDbContext)
        {
            _finspoDbContext = finspoDbContext;
        }
        // GET: api/<MediaController>
        [HttpGet]
        public IActionResult Get()

        {
            return Ok(_finspoDbContext.Media.ToList());
        }

        // GET api/<MediaController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            return Ok(_finspoDbContext.Media.Find(id));
        }

        // POST api/<MediaController>
        [HttpPost]
        public IActionResult Post([FromBody] Media media, string key)
        {
            if (!_finspoDbContext.AuthorizedUser.ToList().Any(au => au.Key == key))
            {
                return StatusCode(StatusCodes.Status401Unauthorized);
            }
            _finspoDbContext.Media.Add(media);
            _finspoDbContext.SaveChanges();
            return Ok(StatusCode(StatusCodes.Status201Created, media));
        }
    }
}
