using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mood_Food.Models.Others
{
    public class CartProduct
    {
        public Product Product { get; set; }
        public int Quantity { get; set; }
        public decimal Value { get; set; }
    }
}