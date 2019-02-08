using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mood_Food.Models
{
    public class Category
    {
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public string NameOfImage { get; set; }
    }
}