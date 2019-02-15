using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.Migrations;

using Mood_Food.Migrations;
using Mood_Food.Models;


namespace Mood_Food.DAL
{
    public class MoodFoodInitializer : MigrateDatabaseToLatestVersion<MoodFoodContext,Configuration>
    {
        public static void SeedMoodFood(MoodFoodContext context)
        {
            List<Category> categories = new List<Category>
            {
                new Category(){ Name="Burgery", Description="Tylko z najwyższej jakości wołowiny!", NameOfImage="Burgery.png"},
                new Category(){ Name="Sałatki", Description="Najświeższe składniki to nasza tajemnica!", NameOfImage="Sałatki.png"},
                new Category(){ Name="Pizze", Description="Na najgrubszym cieście w mieście!", NameOfImage="Pizze.png"},
                new Category(){ Name="Dodatki", Description="Super dodatki za super cenę!", NameOfImage="Dodatki.png"},
            };

            context.Categories.AddOrUpdate(categories.ToArray());
            context.SaveChanges();

            List<Product> products = new List<Product>
            {
                new Product(){ProductId=1, Name="Hamburger", Description="Klasyczny hamburger, plaster wołowiny, cebula i ogórek", CategoryId=1, NameOfImage="Hamburger.png", Price=2.99m, Hidden=false},
                new Product(){ProductId=2, Name="Cheeseburger", Description="Pyszny hamburger z dodatkiem plasterka sera", CategoryId=1, NameOfImage="Cheeseburger.png", Price=3.99m, Hidden=false},
                new Product(){ProductId=3, Name="Sałatka meksykańska", Description="Z ananasem, porem, kukurydzą, papryką, serem żółtym i czerwoną fasolką", CategoryId=2, NameOfImage="SalatkaMeksykanska.png", Price=5.49m, Hidden=false},
                new Product(){ProductId=4, Name="Sałatka z kurczakiem", Description="Mieszanka sałat z burakiem i kawałkami kurczaka w złocistej panierce", CategoryId=2, NameOfImage="SalatkaZKurczakiem.png", Price=4.99m, Hidden=false},
                new Product(){ProductId=5, Name="Pizza Margherita", Description="Pizza z sosem pomidorowym i tartym serem mozzarella.", CategoryId=3, NameOfImage="PizzaMargherita.png", Price=15.99m, Hidden=false},
                new Product(){ProductId=6, Name="Pizza Wiejska", Description="Pizza z sosem pomidorowym, szynką, boczkiem, kiełbasą i cebulą.", CategoryId=3, NameOfImage="PizzaWiejska.png", Price=21.99m, Hidden=false},
                new Product(){ProductId=7, Name="Keczup", Description="Z dojrzewających w słońcu pomidorów.", CategoryId=4, NameOfImage="Keczup.png", Price=0.99m, Hidden=false},
                new Product(){ProductId=8, Name="Musztarda", Description="Bardzo ostra!", CategoryId=4, NameOfImage="Musztarda.png", Price=0.99m, Hidden=false},
            };

            context.Products.AddOrUpdate(products.ToArray());
            context.SaveChanges();
        }
    }
}