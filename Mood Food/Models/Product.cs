using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mood_Food.Models
{
    public class Product
    {
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string NameOfImage { get; set; }
        public decimal Price { get; set; }
        public bool Hidden { get; set; }
    }
}