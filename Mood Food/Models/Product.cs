using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mood_Food.Models
{
    public class Product
    {
        [HiddenInput(DisplayValue = false)]
        public int ProductId { get; set; }
        public int CategoryId { get; set; }
        [Required(ErrorMessage ="Podaj nazwę produktu")]
        [StringLength(100)]
        public string Name { get; set; }
        public string Description { get; set; }
        [StringLength(100)]
        public string NameOfImage { get; set; }
        public decimal Price { get; set; }
        public bool Hidden { get; set; }
    }
}