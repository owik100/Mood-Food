using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mood_Food.Models
{
    public class Order
    {
        public int OrderId { get; set; }
        public string LastName { get; set; }
        public string FirstName { get; set; }
        public string City { get; set; }
        public string Street { get; set; }
        public string ZIPCode { get; set; }
        public int HouseNumber { get; set; }
        public int FlatNumber { get; set; }
        public string PhoneNumber { get; set; }
        public string Emial { get; set; }
        public string Description { get; set; }
        public DateTime OrderDate { get; set; }
        public OrderStatus Status { get; set; }
        public decimal MyProperty { get; set; }
        public decimal OrderValue { get; set; }
    }

    public enum OrderStatus
    {
        New,
        Complited
    }
}