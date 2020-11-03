using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace server.Models
{
    public class Media
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Link { get; set; }
        public string Source { get; set; }
        public int Year { get; set; }
    }
}
