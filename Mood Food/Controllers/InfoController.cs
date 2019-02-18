using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Mood_Food.Controllers
{
    public class InfoController : Controller
    {
        // GET: Info
        public ActionResult StaticSite(string name)
        {
            return View(name);
        }
    }
}