using Mood_Food.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mood_Food.Controllers
{
    public class ProductController : Controller
    {

        [OutputCache(Duration = 600)]
        public ActionResult Categories()
        {
            MoodFoodContext db = new MoodFoodContext();

            var categories = db.Categories.ToList();

            return View(categories);
        }

        [OutputCache(Duration = 600, VaryByContentEncoding = "category")]
        public ActionResult Products(string category="")
        {
            MoodFoodContext db = new MoodFoodContext();

            if (category=="")
            {
                var allProducts = db.Products.ToList();

                return View(allProducts);
            }

            var products = db.Products
                .Where(x => x.Category.Name == category).ToList();

            return View(products);
        }

        [OutputCache(Duration = 600, VaryByContentEncoding ="id")]
        public ActionResult Description(int id)
        {
            MoodFoodContext db = new MoodFoodContext();

           var product = db.Products
                .Where(x => x.ProductId == id)
                .FirstOrDefault();

            return View(product);
        }


        [ChildActionOnly]
        [OutputCache(Duration = 600)]
        public PartialViewResult CategoryNav()
        {
            MoodFoodContext db = new MoodFoodContext();

            var categories = db.Categories.ToList();

            return PartialView("_CategoryNav",categories);
        }
    }
}