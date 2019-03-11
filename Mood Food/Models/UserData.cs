using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Mood_Food.Models
{
    public class UserData
    {
        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string Adress { get; set; }

        public string City { get; set; }

        public string ZIPCode { get; set; }

        [RegularExpression(@"(\+\d{2})*[\d\s-]+", ErrorMessage = "Błędny format numeru telefonu.")]
        public string TelefonPhoneNumber { get; set; }

        [EmailAddress(ErrorMessage = "Błędny format adresu e-mail.")]
        public string Email { get; set; }
    }
}