using Mood_Food.Infrastructure;
using Mood_Food.Models;
using Mood_Food.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mood_Food.DAL;

namespace Mood_Food.Controllers
{
    public class CartController : Controller
    {
        private ShoppingCartManager shoppingCartManager;
        private ISessionManager sessionManager;
        private MoodFoodContext db;

        public CartController()
        {
            db = new MoodFoodContext();
            sessionManager = new SessionManager();
            shoppingCartManager = new ShoppingCartManager(sessionManager, db);
        }

        public ActionResult Index()
        {
            var cartProducts = shoppingCartManager.GetShoppingCart();
            decimal totalValue = shoppingCartManager.CartTotalValue(cartProducts);

            Cart cart = new Cart { CartProducts = cartProducts, TotalValue = totalValue };

            return View(cart);
        }

        public ActionResult Add(int id)
        {
            shoppingCartManager.AddToShoppingCart(id);

            return RedirectToAction("Index");
        }

        public ActionResult Delete(int id)
        {
            shoppingCartManager.DeleteFromCart(id);

            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Order()
        {
            Order order = new Order();

            return View(order);
        }

        [HttpPost]
        public ActionResult Order(Order order)
        {
            if (ModelState.IsValid)
            {
            
                var newOrder = shoppingCartManager.MakeOrder(order);
                shoppingCartManager.EmptyCart();
                
                var oder = db.Orders;

                OrderConfirmationEmail email = new OrderConfirmationEmail();
                email.To = order.Emial;
                email.From = "marcin.owczarz95@gmail.com";
                email.Value = order.OrderValue;
                email.OrderID = order.OrderId;
                email.OrderItems = order.OrderItem;
                email.Send();


                return RedirectToAction("OrderConfirmation");
            }
            else
                return View(order);
        }

        public ActionResult OrderConfirmation()
        {
            return View();
        }
    }
}