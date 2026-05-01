using BalayBalayResort.Models;
using Microsoft.EntityFrameworkCore;

namespace BalayBalayResort.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {
        }

       public DbSet<Amenity> Amenities { get; set; }
       public DbSet<Amenity_Property> Amenities_Properties { get; set; }
       public DbSet<Booking> Bookings { get; set; }
       public DbSet<Feedback> Feedbacks { get; set; }
       public DbSet<Property> Properties { get; set; }
       public DbSet<Transaction> Transactions { get; set; }
       public DbSet<User> Users {  get; set; }
    }
}
