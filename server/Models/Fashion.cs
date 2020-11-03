using Microsoft.AspNetCore.Http.Features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace server.Models
{
    public class Fashion
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Title { get; set; }
        [Required]
        public List<Clothing> Items { get; set; }
        [Required]
        public string Link { get; set; }
        [Required]
        public string? Source { get; set; }

    }
}
