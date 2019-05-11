using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    public class TestController : Controller
    {
        // GET: Test
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Redir()
        {
            ViewBag.Msg = "OK!";
            ViewBag.Url = "/";
            return View("GoRedirect");
        }
    }
}