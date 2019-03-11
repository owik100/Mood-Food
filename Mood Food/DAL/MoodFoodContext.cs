using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Data.Entity.ModelConfiguration.Conventions;

using Mood_Food.Models;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Mood_Food.DAL
{
    public class MoodFoodContext :IdentityDbContext<ApplicationUser>
    {
       public MoodFoodContext() : base("MoodFoodDatabase")
        {
            Database.SetInitializer(new MoodFoodInitializer());
        }

        public static MoodFoodContext Create()
        {
            return new MoodFoodContext();
        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }


        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

    }
}