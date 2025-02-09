using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Context
{
    public class ApplicationDBContext : DbContext
    {
        public ApplicationDBContext(DbContextOptions<ApplicationDBContext> options) : base(options)
        {

        }
        public DbSet<Address> Addresses { get; set; }
        public DbSet<City> City { get; set; }
        public DbSet<Confirm> Confirm { get; set; }
        public DbSet<Country> Country { get; set; }
        public DbSet<District> District { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<Payment> Payment { get; set; }
        public DbSet<Receiver> Receiver { get; set; }
        public DbSet<Star> Star { get; set; }
        public DbSet<Zone> Zone { get; set; }
        public DbSet<OrderType> OrderTypes { get; set; }
        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            // Address - District relationship
            builder.Entity<Address>()
                .HasOne(a => a.District)
                .WithMany(d => d.Addresses)
                .HasForeignKey(a => a.DistrictId);

            // Address - City relationship
            builder.Entity<Address>()
                .HasOne(a => a.City)
                .WithMany(c => c.Addresses)
                .HasForeignKey(a => a.CityId);

            // Address - Zone relationship
            builder.Entity<Address>()
                .HasOne(a => a.Zone)
                .WithMany(z => z.Addresses)
                .HasForeignKey(a => a.ZoneId);

            // Address - Country relationship
            builder.Entity<Address>()
                .HasOne(a => a.Country)
                .WithMany(c => c.Addresses)
                .HasForeignKey(a => a.CountryId);

            // Order - Payment relationship
            builder.Entity<Order>()
                .HasOne(o => o.Cod)
                .WithOne(p => p.Order)
                .HasForeignKey<Order>(p => p.CodId);

            // Order - Confirm relationship
            builder.Entity<Order>()
                .HasOne(o => o.Confirm)
                .WithOne(c => c.Order)
                .HasForeignKey<Order>(o => o.ConfirmId);

            // Order - Receiver relationship
            builder.Entity<Order>()
                .HasOne(o => o.Receiver)
                .WithMany(r => r.Order)
                .HasForeignKey(o => o.ReceiverId);

            // Order - Star relationship
            builder.Entity<Order>()
                .HasOne(o => o.Star)
                .WithMany(s => s.Order)
                .HasForeignKey(o => o.StarId);

            // Order - Address relationship
            builder.Entity<Order>()
                .HasOne(o => o.DropOffAddress)
                .WithMany(a => a.DropOffOrders)
                .HasForeignKey(o => o.DropOffAddressId);

            builder.Entity<Order>()
                .HasOne(o => o.PickupAddress)
                .WithMany(a => a.PickupOrders)
                .HasForeignKey(o => o.PickupAddressId);

            // Order - OrderType relationship
            builder.Entity<Order>()
                .HasOne(o => o.OrderType)
                .WithMany(ot => ot.Orders)
                .HasForeignKey(o => o.TypeId);

            // Add unique constraint
            builder.Entity<City>().HasIndex(c => c.Name).IsUnique();
            builder.Entity<Country>().HasIndex(c => c.Name).IsUnique();
            builder.Entity<District>().HasIndex(d => d.Name).IsUnique();
            builder.Entity<Zone>().HasIndex(z => z.Name).IsUnique();
        }

    }
}