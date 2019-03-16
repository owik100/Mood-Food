using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mood_Food.Models.ViewModels
{
    public class EditProductViewModel
    {
        public Product Product { get; set; }
        public List<Category> Category { get; set; }
    }
}