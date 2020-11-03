using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using server.Data;
using server.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FashionController : ControllerBase
    {
        private FinspoDbContext _finspoDbContext;

        public FashionController(FinspoDbContext finspoDbContext)
        {
            _finspoDbContext = finspoDbContext;
        }

        // GET: api/<InspoController>
        [HttpGet]
        public IActionResult Get()
        {
            var fashion = _finspoDbContext.Fashion;
            List<Fashion> newFashion = new List<Fashion>();
            foreach(var f in fashion.ToList())
            {
                Fashion newFashionItem = new Fashion
                {
                    Id = f.Id,
                    Title = f.Title,
                    Items = _finspoDbContext.Clothing.Where(c => c.FashionId == f.Id).ToList(),
                    Link = f.Link,
                    Source = f.Source
                };
                newFashion.Add(newFashionItem);
            }
            return Ok(newFashion);
        }

        // GET api/<InspoController>/5
        [HttpGet("{id}")]
        public Fashion Get(int id)
        {
            var result = _finspoDbContext.Fashion.Find(id);
            return result;
        }

        // POST api/<InspoController>
        [HttpPost]
        public IActionResult Post([FromBody] Fashion fashion)
        {
            foreach(Clothing item in fashion.Items)
            {
                _finspoDbContext.Clothing.Add(item);
            }
            _finspoDbContext.Fashion.Add(fashion);
            _finspoDbContext.SaveChanges();
            return StatusCode(StatusCodes.Status201Created);
        }

        // PUT api/<InspoController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<InspoController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
