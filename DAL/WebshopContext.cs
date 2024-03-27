using Microsoft.EntityFrameworkCore;
using Model;
using System.Reflection;

namespace DAL
{
    public class WebshopContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductGroup> ProductGroups { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserGroup> UserGroups { get; set; }
        public DbSet<BasketPosition> BasketPositions { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderPosition> OrdersPositions { get; set;}
        public DbSet<Model.Type> Types { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Webshop2;Integrated Security=True;Connect Timeout=30;Encrypt=False;Trust Server Certificate=False;Application Intent=ReadWrite;Multi Subnet Failover=False");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new BasketPosition());
            modelBuilder.ApplyConfiguration(new Order());
            modelBuilder.ApplyConfiguration(new OrderPosition());
            modelBuilder.ApplyConfiguration(new Product());
            modelBuilder.ApplyConfiguration(new ProductGroup());
            modelBuilder.ApplyConfiguration(new Model.Type());
            modelBuilder.ApplyConfiguration(new User());
            modelBuilder.ApplyConfiguration(new UserGroup());
        }
    }
}