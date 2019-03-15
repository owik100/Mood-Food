using Mood_Food.DAL;
using Mood_Food.Models;
using Mood_Food.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mood_Food.Infrastructure
{
    public class ShoppingCartManager
    {
        ISessionManager session;
        MoodFoodContext db;

       public ShoppingCartManager(ISessionManager session, MoodFoodContext db)
        {
            this.session = session;
            this.db = db;
        }

        public List<CartProduct> GetShoppingCart()
        {
            List<CartProduct> shoppingCart;

           if(session.Get<List<CartProduct>>(Constans.SessionShoppingCartKey) == null)
            {
                shoppingCart = new List<CartProduct>();
            }
           else
            {
                shoppingCart = session.Get<List<CartProduct>>(Constans.SessionShoppingCartKey);
            }

            return shoppingCart;
        }

        public void AddToShoppingCart(int id)
        {
            List<CartProduct> shoppingCart = GetShoppingCart();

            var item = shoppingCart.Find(x => x.Product.ProductId == id);

            if(item!=null)
            {
                item.Quantity++;
                item.Value = item.Product.Price * item.Quantity;
            }
            else
            {
                Product product = db.Products.Where(x => x.ProductId == id).FirstOrDefault();


                CartProduct cartProduct = new CartProduct { Product = product, Quantity = 1, Value = product.Price * 1};

                shoppingCart.Add(cartProduct);
            }

            session.Set(Constans.SessionShoppingCartKey, shoppingCart);

        }

        public void DeleteFromCart(int id)
        {
            List<CartProduct> shoppingCart = GetShoppingCart();
            var item = shoppingCart.Find(x => x.Product.ProductId == id);

            if(item!=null)
            {
                item.Quantity--;
                item.Value = item.Product.Price * item.Quantity;

                if (item.Quantity<=0)
                {
                    shoppingCart.Remove(item);
                }
            }

            session.Set(Constans.SessionShoppingCartKey, shoppingCart);
        }

        public Order MakeOrder(Order newOrder)
        {
            List<CartProduct> shoppingCart = GetShoppingCart();
            newOrder.OrderDate = DateTime.Now;

            db.Orders.Add(newOrder);

            if (newOrder.OrderItem == null)
                newOrder.OrderItem = new List<OrderItem>();

            decimal cartValue = 0;

            foreach (var item in shoppingCart)
            {
                var nowaPozycjaZamowienia = new OrderItem()
                {
                    ProductId = item.Product.ProductId,
                    Quantity = item.Quantity,
                    PurchasePrice = item.Product.Price
                };

                cartValue += (item.Quantity * item.Product.Price);
                newOrder.OrderItem.Add(nowaPozycjaZamowienia);
            }

            newOrder.OrderValue = cartValue;
            db.SaveChanges();

            return newOrder;
        }


        public decimal CartTotalValue(List<CartProduct> cart)
        {
            List<CartProduct> shoppingCart = cart;
            decimal value = 0;

            foreach (var item in shoppingCart)
            {
                value += item.Value; 
            }

            return value;
        }

        public void EmptyCart()
        {
            session.Set<List<OrderItem>>(Constans.SessionShoppingCartKey, null);
        }


    }
}