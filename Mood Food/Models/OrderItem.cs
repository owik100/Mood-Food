using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mood_Food.Models
{
    public class OrderItem
    {
        [HiddenInput(DisplayValue = false)]
        public int OrderItemId { get; set; }
        [HiddenInput(DisplayValue = false)]
        public int OrderId { get; set; }
        [HiddenInput(DisplayValue = false)]
        public int ProductId { get; set; }
        public int Quantity { get; set; }
        public decimal PurchasePrice { get; set; }

        public Order Order { get; set; }
        public Product Product { get; set; }
    }
}