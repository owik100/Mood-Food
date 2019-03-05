using Mood_Food.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mood_Food.Models.ViewModels
{
    public class Cart
    {
        public List<CartProduct> CartProducts { get; set; }
        public decimal TotalValue;
    }
}