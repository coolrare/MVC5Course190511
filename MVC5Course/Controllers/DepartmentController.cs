using MVC5Course.ActionFilters;
using MVC5Course.Models;
using MVC5Course.ViewModels;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    public class DepartmentController : BaseController
    {
        ContosoUniversityEntities db = new ContosoUniversityEntities();

        [取得Department清單]
        public ActionResult Index()
        {
            return View(ViewBag.DepartmentList);
        }

        [HttpPost]
        [取得Department清單]
        public ActionResult Index(DepartmentBatchUpdateVM[] data)
        {
            if (ModelState.IsValid)
            {
                foreach (var item in data)
                {
                    var dept = db.Department.Find(item.DepartmentId);
                    dept.Name = item.Name;
                    dept.Budget = item.Budget;
                }

                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(ViewBag.DepartmentList);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(DepartmentCreationVM data)
        {
            if (ModelState.IsValid)
            {
                db.Department.Add(new Department()
                {
                    Budget = data.Budget,
                    Name = data.Name,
                    StartDate = data.StartDate
                });
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(data);
        }
    }
}