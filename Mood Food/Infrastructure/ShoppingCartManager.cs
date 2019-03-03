using Mood_Food.DAL;
using Mood_Food.Models;
using Mood_Food.Models.Others;
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

        ShoppingCartManager(ISessionManager session, MoodFoodContext db)
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

        public void AddToShoppingCart(int id, int quantity)
        {
            List<CartProduct> shoppingCart = GetShoppingCart();

            var item = shoppingCart.Find(x => x.Product.ProductId == id);

            if(item!=null)
            {
                item.Quantity += quantity;
                item.Value = item.Product.Price * item.Quantity;
            }
            else
            {
                Product product = db.Products.Where(x => x.ProductId == id).FirstOrDefault();


                CartProduct cartProduct = new CartProduct { Product = product, Quantity = quantity, Value = product.Price * quantity};

                shoppingCart.Add(cartProduct);
            }

            session.Set(Constans.SessionShoppingCartKey, shoppingCart);

        }

        public void DeleteFromCart(int id, int quantity)
        {
            List<CartProduct> shoppingCart = GetShoppingCart();
            var item = shoppingCart.Find(x => x.Product.ProductId == id);

            if(item!=null)
            {
                item.Quantity -= quantity;
                item.Value = item.Product.Price * item.Quantity;

                if (item.Quantity<=0)
                {
                    shoppingCart.Remove(item);
                }
            }

            session.Set(Constans.SessionShoppingCartKey, shoppingCart);
        }

        public decimal CartValue(List<CartProduct> cart)
        {
            List<CartProduct> shoppingCart = cart;
            decimal value = 0;

            foreach (var item in shoppingCart)
            {
                value += item.Value; 
            }

            return value;
        }


    }
}