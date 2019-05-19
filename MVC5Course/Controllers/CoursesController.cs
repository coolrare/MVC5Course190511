using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using MVC5Course.Models;

namespace MVC5Course.Controllers
{
    [RoutePrefix("c")]
    public class CoursesController : BaseController
    {
        CourseRepository repo;
        DepartmentRepository repoDept;

        public CoursesController()
        {
            repo = RepositoryHelper.GetCourseRepository();
            repoDept = RepositoryHelper.GetDepartmentRepository(repo.UnitOfWork);
        }

        // GET: Courses
        [Route("")]
        public ActionResult Index()
        {
            var course = repo.All();
            return View(course.ToList());
        }

        // GET: Courses/Details/5
        [Route("{id}")]
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = repo.Find(id.Value);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        // GET: Courses/Create
        [Route("create")]
        public ActionResult Create()
        {
            ViewBag.DepartmentID = new SelectList(repoDept.All(), "DepartmentID", "Name");
            return View();
        }

        // POST: Courses/Create
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("create")]
        public ActionResult Create([Bind(Include = "CourseID,Title,Credits,DepartmentID,Location")] Course course)
        {
            if (ModelState.IsValid)
            {
                repo.Add(course);
                repo.UnitOfWork.Commit();
                return RedirectToAction("Index");
            }

            ViewBag.DepartmentID = new SelectList(repoDept.All(), "DepartmentID", "Name", course.DepartmentID);
            return View(course);
        }

        // GET: Courses/Edit/5
        [Route("edit/{id}")]
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = repo.Find(id.Value);
            if (course == null)
            {
                return HttpNotFound();
            }
            ViewBag.DepartmentID = new SelectList(repoDept.All(), "DepartmentID", "Name", course.DepartmentID);
            return View(course);
        }

        // POST: Courses/Edit/5
        // 若要免於過量張貼攻擊，請啟用想要繫結的特定屬性，如需
        // 詳細資訊，請參閱 https://go.microsoft.com/fwlink/?LinkId=317598。
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("edit/{id}")]
        public ActionResult Edit(int id, FormCollection form)
        {
            Course course = repo.Find(id);

            if (TryUpdateModel(course, "", null, new string[] { "Enrollment" }))
            {
                repo.UnitOfWork.Commit();
                return RedirectToAction("Index");
            }

            //if (ModelState.IsValid)
            //{
            //    repo.UnitOfWork.Context.Entry(course).State = EntityState.Modified;
            //    repo.UnitOfWork.Commit();
            //    return RedirectToAction("Index");
            //}

            ViewBag.DepartmentID = new SelectList(repoDept.All(), "DepartmentID", "Name", course.DepartmentID);
            return View(course);
        }

        // GET: Courses/Delete/5
        [Route("delete/{id}")]
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Course course = repo.Find(id.Value);
            if (course == null)
            {
                return HttpNotFound();
            }
            return View(course);
        }

        // POST: Courses/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        [Route("delete/{id}")]
        public ActionResult DeleteConfirmed(int id)
        {
            Course course = repo.Find(id);
            repo.Delete(course);
            repo.UnitOfWork.Commit();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                repo.UnitOfWork.Context.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
