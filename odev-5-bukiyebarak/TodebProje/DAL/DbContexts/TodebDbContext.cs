using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.DbContexts
{
    public class TodebDbContext:DbContext
    {
        private IConfiguration _configuration;
        public TodebDbContext(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public DbSet<Category> Categories { get; set; }
       
        public DbSet<Order> Orders { get; set; }
       
        public DbSet<Product> Products { get; set; }
        public DbSet<ShopCart> ShopCarts { get; set; }
        public DbSet<User> Users { get; set; }

        //Tabloları veritabanına kaydetmek
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            //base.OnConfiguring(optionsBuilder.UseSqlServer("Server=DESKTOP-3290BLE;Database=TodebProject;Trusted_Connection=True"));

            var connectionString = _configuration.GetConnectionString("MsComm");
            base.OnConfiguring(optionsBuilder.UseSqlServer(connectionString));
        }
    }
}
