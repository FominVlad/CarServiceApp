using CarServiceApp.Helpers;
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

        /// <summary>
        /// Registered users list.
        /// </summary>
        public DbSet<User> Users { get; set; }

        /// <summary>
        /// Role types dictionsry.
        /// </summary>
        public DbSet<Role> Roles { get; set; }
        
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
            modelBuilder.Entity<Contact>().Property(c => c.Actual).HasDefaultValue(1);
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
            modelBuilder.Entity<ContactType>().HasData(
                new ContactType[] 
                {
                    new ContactType { Id = 1, Type = "Phone number" },
                    new ContactType { Id = 2, Type = "Email" },
                    new ContactType { Id = 3, Type = "Instagram" },
                    new ContactType { Id = 4, Type = "Facebook" },
                    new ContactType { Id = 5, Type = "Viber" },
                    new ContactType { Id = 6, Type = "Telegram" }
                });

            // Roles configure
            modelBuilder.Entity<Role>().HasKey(r => r.Id).HasName("PK_Roles");
            modelBuilder.Entity<Role>().Property(r => r.RoleName).IsRequired();
            modelBuilder.Entity<Role>().HasData(
                new Role[]
                {
                    new Role { Id = 1, RoleName = "Administrator" },
                    new Role { Id = 2, RoleName = "ViewOnly" },
                    new Role { Id = 3, RoleName = "Employee" }
                });

            // Users configure
            modelBuilder.Entity<User>().HasKey(u => u.Id).HasName("PK_Users");
            modelBuilder.Entity<User>().HasOne(r => r.Role)
                                       .WithMany(u => u.Users)
                                       .HasForeignKey(r => r.RoleId)
                                       .HasConstraintName("FK_Users_Roles");
            modelBuilder.Entity<User>().HasIndex(u => u.Login)
                                       .IsUnique().HasName("UK_User_Login");
            modelBuilder.Entity<User>().Property(u => u.Login).IsRequired();
            modelBuilder.Entity<User>().Property(u => u.Password).IsRequired();
            modelBuilder.Entity<User>().Property(u => u.RoleId).IsRequired();
            modelBuilder.Entity<User>().HasData(
                new User[]
                {
                    new User { Id = 1, Login = "Admin", Password = PasswordManager.GetPassHash("Admin", "adm123"), 
                               Name = "", Surname = "", RoleId = 1 }
                });
        }
    }
}
