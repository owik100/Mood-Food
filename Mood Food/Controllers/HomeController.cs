using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Mood_Food.Models;

using Mood_Food.DAL;

namespace Mood_Food.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            MoodFoodContext db = new MoodFoodContext();

            List<Product> randomProducts;
            randomProducts = db.Products
                .Where(x => x.Category.ShowProductsFromTheseCategoryInHomePage == true)
                .OrderBy(x => Guid.NewGuid())
                .Take(4).ToList();

            return View(randomProducts);
        }
    }
}