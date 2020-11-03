using Microsoft.AspNetCore.Http.Features;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server.Models
{
    public class Fashion
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public List<Clothing> Items { get; set; }
        public string Link { get; set; }
        public string? Source { get; set; }

    }
}
