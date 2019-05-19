using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    public class MBController : BaseController
    {
        public ActionResult Index()
        {
            ViewData["key1"] = "1";
            ViewBag.key2 = "2";

            ViewData.Model = "4";

            return View();
        }

        public ActionResult WriteTemp()
        {
            TempData["key3"] = "3";

            return RedirectToAction("Index");
        }
    }
}