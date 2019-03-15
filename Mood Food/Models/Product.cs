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
        [Display(Name = "Nazwa")]
        [Required(ErrorMessage ="Podaj nazwę produktu")]
        [StringLength(100)]
        public string Name { get; set; }
        [Display(Name = "Opis")]
        public string Description { get; set; }
        [Display(Name = "Nazwa obrazka")]
        [StringLength(100)]
        public string NameOfImage { get; set; }
        [Required(ErrorMessage = "Podaj cenę produktu")]
        [Display(Name = "Cena")]
        public decimal Price { get; set; }
        [Display(Name = "Ukryty")]
        public bool Hidden { get; set; }

        public Category Category { get; set; }
    }
}