using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarServiceApp.Models;
using Microsoft.EntityFrameworkCore;

namespace CarServiceApp
{
    public class AppDbContext : DbContext
    {
        /// <summary>
        /// Customers of automobile service.
        /// </summary>
        public DbSet<Customer> Customers { get; set; }

        /// <summary>
        /// Cars that were repaired in automobile service.
        /// </summary>
        public DbSet<Car> Cars { get; set; }

        /// <summary>
        /// Join table of customers and them cars.
        /// </summary>
        public DbSet<CustomerCar> CustomerCars { get; set; }

        /// <summary>
        /// Fuel types dictionary.
        /// </summary>
        public DbSet<FuelType> FuelTypes { get; set; }

        /// <summary>
        /// Car models dictionary.
        /// </summary>
        public DbSet<CarModel> CarModels { get; set; }

        /// <summary>
        /// Contact list.
        /// </summary>
        public DbSet<Contact> Contacts { get; set; }

        /// <summary>
        /// Contact types dictionary.
        /// </summary>
        public DbSet<ContactType> ContactTypes { get; set; }

        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Customers configure
            modelBuilder.Entity<Customer>().HasKey(c => c.Id).HasName("PK_Customers");

            // Cars configure
            modelBuilder.Entity<Car>().HasKey(c => c.VIN).HasName("PK_Cars");
            modelBuilder.Entity<Car>().Property(c => c.VIN).ValueGeneratedNever();
            modelBuilder.Entity<Car>().HasOne(c => c.FuelType)
                                      .WithMany(f => f.Cars)
                                      .HasForeignKey(c => c.FuelTypeId)
                                      .HasConstraintName("FK_Cars_FuelTypes");
            modelBuilder.Entity<Car>().HasOne(c => c.CarModel)
                                      .WithMany(m => m.Cars)
                                      .HasForeignKey(c => c.CarModelId)
                                      .HasConstraintName("FK_Cars_CarModels");

            // CustomerCars configure
            modelBuilder.Entity<CustomerCar>().HasKey(cc => cc.Id).HasName("PK_CustomerCars");
            modelBuilder.Entity<CustomerCar>().Property(cc => cc.Actual).HasDefaultValue(1);
            modelBuilder.Entity<CustomerCar>().HasOne(joiner => joiner.Customer)
                                              .WithMany(cust => cust.CustomerCars)
                                              .HasForeignKey(joiner => joiner.CustomerId)
                                              .HasConstraintName("FK_CustomerCars_Customers");
            modelBuilder.Entity<CustomerCar>().HasOne(joiner => joiner.Car)
                                              .WithMany(car => car.CustomerCars)
                                              .HasForeignKey(joiner => joiner.CarId)
                                              .HasConstraintName("FK_CustomerCars_Cars");

            // FuelTypes configure
            modelBuilder.Entity<FuelType>().HasKey(ft => ft.id).HasName("PK_FuelTypes");

            // CarModels configure
            modelBuilder.Entity<CarModel>().HasKey(cm => cm.Id).HasName("PK_CarModels");

            // Contacts configure
            modelBuilder.Entity<Contact>().HasKey(c => c.Id).HasName("PK_Contacts");
            modelBuilder.Entity<Contact>().HasOne(c => c.ContactType)
                                          .WithMany(ct => ct.Contacts)
                                          .HasForeignKey(c => c.ContactTypeId)
                                          .HasConstraintName("FK_Contacts_ContactTypes");
            modelBuilder.Entity<Contact>().HasOne(c => c.Customer)
                                          .WithMany(cu => cu.Contacts)
                                          .HasForeignKey(c => c.CustomerId)
                                          .HasConstraintName("FK_Contacts_Customers");

            // ContactTypes configure
            modelBuilder.Entity<ContactType>().HasKey(ct => ct.Id).HasName("PK_ContactTypes");
        }
    }
}
