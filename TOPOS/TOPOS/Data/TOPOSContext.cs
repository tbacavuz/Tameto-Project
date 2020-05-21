using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TOPOS.Models;

namespace TOPOS.Data
{
    public class TOPOSContext : DbContext
    {
        // You can add custom code to this file. Changes will not be overwritten.
        // 
        // If you want Entity Framework to drop and regenerate your database
        // automatically whenever you change your model schema, please use data migrations.
        // For more information refer to the documentation:
        // http://msdn.microsoft.com/en-us/data/jj591621.aspx
    
        public TOPOSContext() : base("name=TOPOSContext")
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<OrderDetails>()
                .HasRequired<Orders>(o => o.Orders)
                .WithMany(o => o.OrderDetails)
                .HasForeignKey<long>(o => o.OrderId);
        }

        public System.Data.Entity.DbSet<TOPOS.Models.Users> Users { get; set; }

        public System.Data.Entity.DbSet<TOPOS.Models.Roles> Roles { get; set; }

        public System.Data.Entity.DbSet<TOPOS.Models.Customers> Customers { get; set; }

        public System.Data.Entity.DbSet<TOPOS.Models.ProductTypes> ProductTypes { get; set; }

        public System.Data.Entity.DbSet<TOPOS.Models.Products> Products { get; set; }

        public System.Data.Entity.DbSet<TOPOS.Models.Carts> Carts { get; set; }

        public System.Data.Entity.DbSet<TOPOS.Models.CartDetails> CartDetails { get; set; }

        public System.Data.Entity.DbSet<TOPOS.Models.Orders> Orders { get; set; }

        public System.Data.Entity.DbSet<TOPOS.Models.OrderDetails> OrderDetails { get; set; }
    }
}
