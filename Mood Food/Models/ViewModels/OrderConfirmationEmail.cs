using Postal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mood_Food.Models.ViewModels
{
    public class OrderConfirmationEmail : Email
    {
        public string To { get; set; }
        public string From { get; set; }
        public decimal Value { get; set; }
        public int OrderID { get; set; }
        public List<OrderItem> OrderItems { get; set; }
    }
}