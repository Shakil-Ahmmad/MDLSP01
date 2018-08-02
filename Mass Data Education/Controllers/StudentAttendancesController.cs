using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Mass_Data_Education.Models;
using Mass_Data_Education.Repository;

namespace Mass_Data_Education.Controllers
{
    public class StudentAttendancesController : Controller
    {


        RepStudentAttendance db = new RepStudentAttendance();

        public ActionResult Index()
        {
            var data = db.GetAll();
            return View(data.ToList());
        }

        public ActionResult Details(int id = 0)
        {
            StudentAttendance StudentAttendance = db.GetById(id);
            if (StudentAttendance == null)
            {
                return HttpNotFound();
            }
            return View(StudentAttendance);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,ClassID,PersonID,Date,IsPresent,Deleted")] StudentAttendance StudentAttendance)
        {
            if (ModelState.IsValid)
            {
                db.Add(StudentAttendance);
                return RedirectToAction("Index");
            }

            return View(StudentAttendance);
        }

        public ActionResult Edit(int id = 0)
        {
            StudentAttendance user = db.GetById(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,ClassID,PersonID,Date,IsPresent,Deleted")] StudentAttendance StudentAttendance)
        {
            if (ModelState.IsValid)
            {
                db.Update(StudentAttendance);
                return RedirectToAction("Index");
            }
            return View(StudentAttendance);
        }

        public ActionResult Delete(int id = 0)
        {
            StudentAttendance user = db.GetById(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            db.Delete(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        
    }
}
