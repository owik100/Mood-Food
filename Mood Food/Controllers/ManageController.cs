using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin.Security;
using Mood_Food.DAL;
using Mood_Food.Infrastructure;
using Mood_Food.Models;
using Mood_Food.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;
using static Mood_Food.App_Start.IdentityConfig;

namespace Mood_Food.Controllers
{

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
            EditProductViewModel prod = new EditProductViewModel();
            prod.Category = db.Categories.ToList();

            if (id != null)
            {
                ViewBag.BtnContext = "Zaaktualizuj";
                var product = db.Products
               .Include("Category")
               .Where(x => x.ProductId == id)
               .FirstOrDefault();

                prod.Product = product;

                return View(prod);

            }
            else
            {
                ViewBag.BtnContext = "Dodaj";
                return View(prod);
            }
        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ProductEdit(EditProductViewModel model, HttpPostedFileBase file)
        {
            ModelState.Remove("Product.ProductId");
            if (ModelState.IsValid)
            {

                if (file != null && file.ContentLength > 0)
                {

                    var filename = file.FileName;
                    var folderPath = ConfigurationManager.AppSettings["ProductsImagePath"];
                    var path = Path.Combine(Server.MapPath(folderPath), filename);

                    model.Product.NameOfImage = file.FileName;

                    file.SaveAs(path);
                    model.Product.NameOfImage = filename;
                }


                //Edycja
                if (model.Product.ProductId > 0)
                {

                    db.Entry(model.Product).State = EntityState.Modified;
                    db.SaveChanges();

                    TempData["Message"] = "Sukces! zaktualizowano produkt";
                    return RedirectToAction("Index");
                }
                //Nowy
                else
                {
                    
                    db.Products.Add(model.Product);
                    db.SaveChanges();

                    TempData["Message"] = "Sukces! Dodano nowy produkt";
                    return RedirectToAction("Index");
                }
            }
            else
            {
                model.Category = db.Categories.ToList();
                return View(model);
            }

        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ProductDelete(int id)
        {
           var product = db.Products.Find(id);
            if(product!=null)
            {
                db.Products.Remove(product);
                db.SaveChanges();
                TempData["Message"] = "Sukces! Usunięto produkt";
            }
            return RedirectToAction("Index");
        }
    }
}