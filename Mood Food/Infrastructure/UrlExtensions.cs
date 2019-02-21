using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mood_Food.Infrastructure
{
    public static class UrlExtensions
    {
        public static string ImagePath(this UrlHelper helper, string imageName)
        {
            string path = System.Configuration.ConfigurationManager.AppSettings["ImagePath"];
            return Path.Combine(path + imageName);
        }

        public static string ProductImagePath(this UrlHelper helper, string imageName)
        {
            string path = System.Configuration.ConfigurationManager.AppSettings["ProductsImagePath"];
            return Path.Combine(path + imageName);
        }

        public static string CategoriesImagePath(this UrlHelper helper, string imageName)
        {
            string path = System.Configuration.ConfigurationManager.AppSettings["CategoriesImagePath"];
            return Path.Combine(path + imageName);
        }
    }
}