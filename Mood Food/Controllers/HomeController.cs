﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using Mood_Food.DAL;

namespace Mood_Food.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            using (var context = new MoodFoodContext())
            {
                context.Database.CreateIfNotExists();
            }

                ViewBag.TestValue = DateTime.Now;
            return View();
        }
    }
}