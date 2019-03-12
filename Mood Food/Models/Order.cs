using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mood_Food.Models
{
    public class Order
    {
        [HiddenInput(DisplayValue = false)]
        public int OrderId { get; set; }
        [Required(ErrorMessage = "Podaj imię")]
        [StringLength(50)]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Podaj nazwisko")]
        [StringLength(50)]
        public string LastName { get; set; }
        [Required(ErrorMessage = "Podaj miasto")]
        [StringLength(50)]
        public string City { get; set; }
        [Required(ErrorMessage = "Podaj ulicę")]
        [StringLength(50)]
        public string Street { get; set; }
        [Required(ErrorMessage = "Podaj kod pocztowy")]
        [StringLength(6)]
        public string ZIPCode { get; set; }
        [Required(ErrorMessage = "Podaj numer domu")]
        [StringLength(4)]
        public string HouseNumber { get; set; }
        [StringLength(4)]
        public string FlatNumber { get; set; }
        [Required(ErrorMessage = "Podaj numer telefonu")]
        [StringLength(20)]
        public string PhoneNumber { get; set; }
        [Required(ErrorMessage = "Podaj adres email")]
        [EmailAddress(ErrorMessage = "Błędny format adresu email.")]
        public string Emial { get; set; }
        public string Description { get; set; }
        public DateTime OrderDate { get; set; }
        public OrderStatus Status { get; set; }
        public decimal OrderValue { get; set; }

        public List<OrderItem> OrderItem { get; set; }
    }

    public enum OrderStatus
    {
        New,
        Complited
    }
}