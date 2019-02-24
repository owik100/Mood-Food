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
        // GET: Product
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Categories()
        {
            MoodFoodContext db = new MoodFoodContext();

            var categories = db.Categories.ToList();

            return View(categories);
        }

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


    }
}