using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mood_Food.Models
{
    public class Category
    {
        [HiddenInput(DisplayValue =false)]
        public int CategoryId { get; set; }
        [Required(ErrorMessage = "Podaj nazwę kategorii")]
        [StringLength(100)]
        public string Name { get; set; }
        [Required(ErrorMessage = "Podaj opis kategorii")]
        public string OpisKategorii { get; set; }
        public string Description { get; set; }
        public string NameOfImage { get; set; }

        public ICollection<Product> Product { get; set; }
    }
}