using aspnet_core_basic.Models;
using Microsoft.EntityFrameworkCore;

namespace aspnet_core_basic.Data
{
    public class OdeToFoodDbContext : DbContext
    {
        public OdeToFoodDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Restaurant> Restaurants { get; set; }
    }
}