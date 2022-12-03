using EssoOtomationProject.Models;
using Microsoft.EntityFrameworkCore;

namespace EssoOtomationProject.Data
{
    public class EssoContext : DbContext
    {
        public EssoContext(DbContextOptions<EssoContext> options) : base(options)
        {
            Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        public DbSet<User> User { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<Country> Country { get; set; }
    }
}
