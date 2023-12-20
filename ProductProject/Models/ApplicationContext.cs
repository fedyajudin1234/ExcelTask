using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductProject.Models
{
    public class ApplicationContext: DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<Link> Links { get; set; }
        public ApplicationContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            dbContextOptionsBuilder.UseSqlServer("Server=(localdb)\\mssqllocaldb;Database=ProductDB;Trusted_Connection=True");
        }
    }
}
