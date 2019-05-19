using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    public class ARController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Index2()
        {
            return PartialView();
        }

        public ActionResult ContentTest()
        {
            return Content("71932749127349217348");
        }

        [Route("robots.txt")]
        public string Robots()
        {
            return @"User-agent: *
Disallow: /Account/*.*
Disallow: /search
Disallow: /search.aspx
Disallow: /error404.aspx
Disallow: /archive
Disallow: /archive.aspx

sitemaps: https://blog.miniasp.com/sitemap.axd
";
        }

        public ActionResult FileTest(bool dl = false)
        {
            var file = Server.MapPath("~/Content/nasa-53884-unsplash.jpg");

            if (dl)
            {
                return File(file, "image/jpeg", "Download.jpg");
            }
            else
            {
                return File(file, "image/jpeg");
            }
        }

        [OutputCache(NoStore = true, Duration = 0)]
        public ActionResult JsonTest()
        {
            return Json(new {
                Id = 1,
                Name = "Will"
            }, JsonRequestBehavior.AllowGet);
        }
    }
}