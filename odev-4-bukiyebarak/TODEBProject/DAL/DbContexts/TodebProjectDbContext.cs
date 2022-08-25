using Microsoft.EntityFrameworkCore;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DbContexts
{
    //Entities kısmında oluşan yapıları tablo halinde oluşturma
    public class TodebProjectDbContext:DbContext
    {
        public DbSet<Category> Categories { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrdersProducts> OrdersProducts { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ShopCart> ShopCarts { get; set; }
        public DbSet<User> Users { get; set; }

        //Tabloları veritabanına kaydetmek
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder.UseSqlServer("Server=DESKTOP-3290BLE;Database=TodebProjectDB;Trusted_Connection=True"));
        }
    }
}
