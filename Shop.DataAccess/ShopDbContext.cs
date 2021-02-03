using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Shop.Models;
using System.Collections.Generic;

namespace Shop.DataAccess
{
    public class ShopDbContext : IdentityDbContext
    {
        public ShopDbContext(DbContextOptions options) : base(options)
        {
        }

        public DbSet<Category> Category { get; set; }
        public DbSet<FoodType> FoodType { get; set; }
        public DbSet<MenuItem> MenuItem { get; set; }
        public DbSet<ApplicationUser> ApplicationUser { get; set; }
        public DbSet<ShoppingCart> ShoppingCart { get; set; }
        public DbSet<OrderHeader> OrderHeader { get; set; }
        public DbSet<OrderDetails> OrderDetails { get; set; }
    }
}
