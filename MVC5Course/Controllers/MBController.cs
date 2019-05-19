using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    public class MBController : BaseController
    {
        public ActionResult Index(string key1, string key2)
        {
            ViewData["key1"] = key1;
            ViewBag.key2 = key2;

            ViewData.Model = "4";

            return View();
        }

        public ActionResult WriteTemp()
        {
            TempData["key3"] = "3";

            Session["key5"] = "5";

            return RedirectToAction("Index");
        }
    }
}