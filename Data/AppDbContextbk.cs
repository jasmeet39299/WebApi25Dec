using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using WebApi25Dec.Models;

namespace WebApi25Dec.Data
{
    public class AppDbContextbk : DbContext
    {
        public AppDbContextbk(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
    }
}
