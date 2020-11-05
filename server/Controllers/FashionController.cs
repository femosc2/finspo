using System;
using System.Collections.Generic;
using System.Diagnostics;
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
        public IActionResult Get(int id)
        {
            return Ok(_finspoDbContext.Fashion.Find(id));
        }

        [HttpGet("GetWhichIncludeBrand/{brand}")]
        public IActionResult GetWhichIncludeBrand(string brand)
        {
            var clothes =_finspoDbContext.Clothing.Where(c => c.Brand.ToLower() == brand.ToLower()).ToList();
            List<Fashion> fashion = new List<Fashion>();
            foreach (var c in clothes)
            {
                foreach (var f in _finspoDbContext.Fashion.ToList())
                {
                    if (f.Id == c.FashionId)
                    {
                        Fashion newFashion = new Fashion
                        {
                            Id = f.Id,
                            Title = f.Title,
                            Items = _finspoDbContext.Clothing.Where(c => c.FashionId == f.Id).ToList(),
                            Link = f.Link,
                            Source = f.Source
                        };
                        fashion.Add(newFashion);
                    }
                }
            }
            return Ok(fashion);
        }

        [HttpGet("GetWhichIncludeColour/{colour}")]
        public IActionResult GetWhichIncludeColour(string colour)
        {
            var clothes = _finspoDbContext.Clothing.Where(c => c.Colour.ToLower() == colour.ToLower()).ToList();
            List<Fashion> fashion = new List<Fashion>();
            foreach (var c in clothes)
            {
                foreach (var f in _finspoDbContext.Fashion.ToList())
                {
                    if (f.Id == c.FashionId)
                    {
                        Fashion newFashion = new Fashion
                        {
                            Id = f.Id,
                            Title = f.Title,
                            Items = _finspoDbContext.Clothing.Where(c => c.FashionId == f.Id).ToList(),
                            Link = f.Link,
                            Source = f.Source
                        };
                        fashion.Add(newFashion);
                    }
                }
            }
            return Ok(fashion);
        }

        [HttpGet("GetWhichIncludeCategory/{category}")]
        public IActionResult GetWhichIncludeCategory(string category)
        {
            var clothes = _finspoDbContext.Clothing.Where(c => c.Category.ToLower() == category.ToLower()).ToList();
            List<Fashion> fashion = new List<Fashion>();
            foreach (var c in clothes)
            {
                foreach (var f in _finspoDbContext.Fashion.ToList())
                {
                    if (f.Id == c.FashionId)
                    {
                        Fashion newFashion = new Fashion
                        {
                            Id = f.Id,
                            Title = f.Title,
                            Items = _finspoDbContext.Clothing.Where(c => c.FashionId == f.Id).ToList(),
                            Link = f.Link,
                            Source = f.Source
                        };
                        fashion.Add(newFashion);
                    }
                }
            }
            return Ok(fashion);
        }

        // POST api/<InspoController>
        [HttpPost]
        public IActionResult Post([FromBody] Fashion fashion, string key)
        {
            if (!_finspoDbContext.AuthorizedUser.ToList().Any(au => au.Key == key))
            {
                return StatusCode(StatusCodes.Status401Unauthorized);
            }

            foreach(Clothing item in fashion.Items)
            {
                _finspoDbContext.Clothing.Add(item);
            }
            _finspoDbContext.Fashion.Add(fashion);
            _finspoDbContext.SaveChanges();
            return StatusCode(StatusCodes.Status201Created, fashion);
        }
    }
}
