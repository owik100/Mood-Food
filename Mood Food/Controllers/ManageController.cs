using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Mood_Food.DAL;
using Mood_Food.Models;
using Mood_Food.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using static Mood_Food.App_Start.IdentityConfig;

namespace Mood_Food.Controllers
{
    [Authorize]
    public class ManageController : Controller
    {
        private MoodFoodContext db;

        public ManageController()
        {
            db = new MoodFoodContext();
        }

        private ApplicationUserManager _userManager;
        public ApplicationUserManager UserManager
        {
            get
            {
                return _userManager ?? HttpContext.GetOwinContext().GetUserManager<ApplicationUserManager>();
            }
            private set
            {
                _userManager = value;
            }
        }

        private IAuthenticationManager AuthenticationManager
        {
            get
            {
                return HttpContext.GetOwinContext().Authentication;
            }
        }


        // GET: Manage
        public async Task<ActionResult> Index()
        {
            var name = User.Identity.Name;

            if (!User.IsInRole("Admin"))
            {
                TempData["Message"] = "Nie masz uprawnień administratora!";
                return View("Error");
            }

            else
            {
                var user = await UserManager.FindByIdAsync(User.Identity.GetUserId());
                if (user == null)
                {
                    return View("Error");
                }

                // return View(model);
                return RedirectToAction("AllProducts");
            }
        }

        [Authorize(Roles = "Admin")]
        public ActionResult AllProducts()
        {
            var products = db.Products
                .Include("Category")
                .ToList();
            return View(products);
        }


        [Authorize(Roles = "Admin")]
        [HttpGet]
        public ActionResult ProductEdit(int? id)
        {
            var product = db.Products
                .Include("Category")
                .Where(x => x.ProductId == id)
                .FirstOrDefault();
            return View(product);
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ProductEdit(Product product)
        {

            if (ModelState.IsValid)
            {
           

                if (product != null)
                {
                    db.Entry(product).State = EntityState.Modified;

                    TempData["Message"] = "Sukces!";
                    return RedirectToAction("ProductEdit");
                }
                else
                {
                    return View(product);
                }
            }
            else
            {
                return View(product);
            }

        }
    }
}