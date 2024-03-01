using Microsoft.EntityFrameworkCore;
using RealEstate.Models;

namespace RealEstate.Data
{
    // Student ID: 00013836
    public class RealEstate_DbContext : DbContext
    {
        public RealEstate_DbContext(DbContextOptions<RealEstate_DbContext> options) : base(options) { }

        // Models
        public DbSet<Apartment> Apartments { get; set; }

        public DbSet<Location> Locations { get; set; }

        public DbSet<Vendor> Vendors { get; set; }



        // Setting relationships between entities
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            // one to many 
            // one location might have several apartments
            modelBuilder.Entity<Apartment>()
                .HasOne(address => address.Location_)
                .WithMany()
                .HasForeignKey(address => address.Location_Id);

            // one to many
            // one vendor might sell several apartments
            modelBuilder.Entity<Apartment>()
                .HasOne(category => category.Vendor_)
                .WithMany()
                .HasForeignKey(category => category.Vendor_Id);
        }
    }
}
