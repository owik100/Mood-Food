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
    public class MoodFoodInitializer : MigrateDatabaseToLatestVersion<MoodFoodContext, Configuration>
    {
        public static void SeedMoodFood(MoodFoodContext context)
        {
            List<Category> categories = new List<Category>
            {
                new Category(){CategoryId=1, Name="Burgery", Description="Tylko z najwyższej jakości wołowiny!", NameOfImage="Burgery.jpeg", ShowProductsFromTheseCategoryInHomePage = true},
                new Category(){CategoryId=2, Name="Sałatki", Description="Najświeższe składniki to nasza tajemnica!", NameOfImage="Sałatki.jpeg", ShowProductsFromTheseCategoryInHomePage = true},
                new Category(){CategoryId=3, Name="Pizze", Description="Na najgrubszym cieście w mieście!", NameOfImage="Pizze.jpeg", ShowProductsFromTheseCategoryInHomePage = true},
                new Category(){CategoryId=4, Name="Dodatki", Description="Super dodatki za super cenę!", NameOfImage="Dodatki.jpeg", ShowProductsFromTheseCategoryInHomePage = false},
            };

            context.Categories.AddOrUpdate(categories.ToArray());
            context.SaveChanges();

            List<Product> products = new List<Product>
            {
                new Product(){ProductId=1, Name="Hamburger", Description="Klasyczny hamburger, plaster wołowiny, cebula i ogórek", CategoryId=1, NameOfImage="Hamburger.jpeg", Price=2.99m, Hidden=false},
                new Product(){ProductId=2, Name="Cheeseburger", Description="Pyszny hamburger z dodatkiem plasterka sera", CategoryId=1, NameOfImage="Cheeseburger.jpeg", Price=3.99m, Hidden=false},
                new Product(){ProductId=3, Name="Sałatka meksykańska", Description="Z ananasem, porem, kukurydzą, papryką, serem żółtym i czerwoną fasolką", CategoryId=2, NameOfImage="SalatkaMeksykanska.jpeg", Price=5.49m, Hidden=false},
                new Product(){ProductId=4, Name="Sałatka z kurczakiem", Description="Mieszanka sałat z burakiem i kawałkami kurczaka w złocistej panierce", CategoryId=2, NameOfImage="SalatkaZKurczakiem.jpeg", Price=4.99m, Hidden=false},
                new Product(){ProductId=5, Name="Pizza Margherita", Description="Pizza z sosem pomidorowym i tartym serem mozzarella.", CategoryId=3, NameOfImage="PizzaMargherita.jpeg", Price=15.99m, Hidden=false},
                new Product(){ProductId=6, Name="Pizza Wiejska", Description="Pizza z sosem pomidorowym, szynką, boczkiem, kiełbasą i cebulą.", CategoryId=3, NameOfImage="PizzaWiejska.jpeg", Price=21.99m, Hidden=false},
                new Product(){ProductId=7, Name="Keczup", Description="Z dojrzewających w słońcu pomidorów.", CategoryId=4, NameOfImage="Keczup.jpeg", Price=0.99m, Hidden=false},
                new Product(){ProductId=8, Name="Musztarda", Description="Bardzo ostra!", CategoryId=4, NameOfImage="Musztarda.jpeg", Price=0.99m, Hidden=false},
            };

            context.Products.AddOrUpdate(products.ToArray());
            context.SaveChanges();
        }
    }
}