using Microsoft.EntityFrameworkCore;
using WebShop.Services.ProductAPI.Models;

namespace WebShop.Services.ProductAPI.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) 
        {
        }

        public DbSet<Product> Product { get; set; }
    }
}