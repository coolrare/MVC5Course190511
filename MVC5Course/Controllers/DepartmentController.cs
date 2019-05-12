using MVC5Course.ViewModels;
using MVC5Course.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVC5Course.Controllers
{
    public class DepartmentController : BaseController
    {
        ContosoUniversityEntities db = new ContosoUniversityEntities();

        public ActionResult Index()
        {
            var data = from p in db.Department
                       select new DepartmentCreationVM()
                       {
                           Name = p.Name,
                           Budget = p.Budget,
                           StartDate = p.StartDate
                       };
            return View(data.ToList());
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