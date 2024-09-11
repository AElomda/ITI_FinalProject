using FinalProject1.Models;
using Microsoft.EntityFrameworkCore;

namespace FinalProject1.Context
{
    public class MyContect: DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.;Database=FinalProject;Trusted_Connection=True;Encrypt=false");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            var _Products = new List<Product>
            {
                 new Product { Id = 1, Title = "Smartphone X1", Price = 699.99m, Description = "Latest smartphone with advanced features", Quantity = 50, ImagePath = "/images/smartphone.jpg",CategoryId = 1  },
                 new Product { Id = 2, Title = "4K Ultra HD TV", Price = 999.99m, Description = "High-definition 4K television", Quantity = 30, ImagePath = "/images/tv.jpg", CategoryId = 1 },
                 new Product { Id = 3, Title = "The Great Adventure Book", Price = 19.99m, Description = "A thrilling fiction novel", Quantity = 100, ImagePath = "/images/book.jpg", CategoryId = 2 },
                 new Product { Id = 4, Title = "Blender Pro", Price = 59.99m, Description = "High-speed blender with multiple settings", Quantity = 20, ImagePath = "/images/blender.jpg", CategoryId = 3 },
                 new Product { Id = 5, Title = "Noise-Cancelling Headphones", Price = 199.99m, Description = "Headphones with active noise cancellation", Quantity = 80, ImagePath = "/images/headphones.jpg", CategoryId = 1 }
            };

            var _Users = new List<User>
            {
                new User { Id = 1, FirstName= "Ahmed",LastName= "Ali",Password = "Password123",Email="Ahmed@Gmail.com"},
                new User { Id = 2, FirstName= "Samy" ,LastName= "Zain" ,Password = "Password123",Email="B@Gmail.com"},
                new User { Id = 3, FirstName= "Ali"  ,LastName= "Marwan"  ,Password = "Password123",Email="C@Gmail.com"},
                new User { Id = 4, FirstName= "Samer",LastName= "Mohamed",Password = "Password123",Email="D@Gmail.com"},
                new User { Id = 5, FirstName= "Mayar",LastName= "Shrif",Password = "Password123",Email = "E@Gmail.com"},
                new User { Id = 6, FirstName= "osama",LastName= "Adly",Password = "Password123",Email = "F@Gmail.com"},
                new User { Id = 7, FirstName= "Sara" ,LastName= "Salem" ,Password = "Password123",Email = "G@Gmail.com"},
                new User { Id = 8, FirstName= "zain" ,LastName= "Ali" ,Password = "Password123",Email = "H@Gmail.com"},
                new User { Id = 9, FirstName= "Mahmoud",LastName= "Salah",Password = "Password123",Email = "I@Gmail.com"},
                new User { Id = 10,FirstName = "yahia",LastName = "Azmey",Password = "Password123",Email = "J@Gmail.com"},
                new User { Id = 11,FirstName = "tarek",LastName = "Ahmed", Password = "Password123" ,Email = "K@Gmail.com"},
                new User { Id = 12,FirstName = "mansour",LastName = "Ahmed", Password = "Password123",Email = "L@Gmail.com"}
            };
            var _Categories = new List<Category>
            {
                new Category { Id = 1, Name = "Electronics", Description = "Devices, gadgets, and accessories" },
                new Category { Id = 2, Name = "Books", Description = "Fiction, non-fiction, and more" },
                new Category { Id = 3, Name = "Home Appliances", Description = "Appliances for home use" }
            };

            modelBuilder.Entity<User>().HasData(_Users);
            modelBuilder.Entity<Product>().HasData(_Products);
            modelBuilder.Entity<Category>().HasData(_Categories);


        }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Product> Products { get; set; }
        public virtual DbSet<Category> Categories { get; set; }
    }
}
