using Microsoft.EntityFrameworkCore;
using TourismWebsite.Models;

namespace TourismWebsite.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }


        public DbSet<Booking> Booking { get; set; }

        public DbSet<Tourist> Tourist { get; set; }

        public DbSet<Guide> Guide { get; set; }

        public DbSet<Destination> Destination { get; set; }

        public DbSet<Agency> Agency { get; set; }
    }
}

//PM> Add-Migration Tourism -context DataContext
//PM> update-database -context DataContext
