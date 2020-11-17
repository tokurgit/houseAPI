using Microsoft.EntityFrameworkCore;

namespace HouseApi.Models
{
    public class HouseApiDbContext : DbContext
    {
        public HouseApiDbContext(DbContextOptions<HouseApiDbContext> options) : base(options)
        {
        }

        public DbSet<House> Houses { get; set; }
        public DbSet<Flat> Flats { get; set; }
        public DbSet<Resident> Residents { get; set; }
    }
}