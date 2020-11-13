using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace HouseApi.Models
{
    public class HouseApiDbContext: DbContext
    {
        public HouseApiDbContext(DbContextOptions<HouseApiDbContext> options) : base(options)
        {
        }

        public DbSet<House> Houses { get; set; }
        public DbSet<Flat> Flats { get; set; }
        public DbSet<Resident> Residents { get; set; }
    }
}