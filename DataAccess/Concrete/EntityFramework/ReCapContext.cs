using Entities.Concrete;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Concrete.EntityFramework
{
    public class ReCapContext : DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=(localdb)msssqllocaldb;Database=ReCapDatabase;Trusted_Connection=true");
        }

        public DbSet<Car> Cars { get; set; }
    }
}
