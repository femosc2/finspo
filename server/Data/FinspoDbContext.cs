using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using server.Models;

namespace server.Data
{
    public class FinspoDbContext : DbContext
    {
        public FinspoDbContext(DbContextOptions<FinspoDbContext> options) : base(options)
        {
            
        }
        public DbSet<Fashion> Fashion { get; set; }
        public DbSet<Clothing> Clothing { get; set; }
        public DbSet<Media> Media { get; set; }
    }
}
