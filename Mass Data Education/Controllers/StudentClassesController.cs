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
    public class StudentClassesController : Controller
    {

        RepStudentClass db = new RepStudentClass();

        public ActionResult Index()
        {
            var data = db.GetAll();
            return View(data.ToList());
        }

        public ActionResult Details(int id = 0)
        {
            StudentClass StudentClass = db.GetById(id);
            if (StudentClass == null)
            {
                return HttpNotFound();
            }
            return View(StudentClass);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,PersonId,Roll,ClassFee,ClassID,Year,IsActive,Deleted")] StudentClass StudentClass )
        {
            if (ModelState.IsValid)
            {
                db.Add(StudentClass);
                return RedirectToAction("Index");
            }

            return View(StudentClass);
        }

        public ActionResult Edit(int id = 0)
        {
            StudentClass user = db.GetById(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,PersonId,Roll,ClassFee,ClassID,Year,IsActive,Deleted")] StudentClass StudentClass)
        {
            if (ModelState.IsValid)
            {
                db.Update(StudentClass);
                return RedirectToAction("Index");
            }
            return View(StudentClass);
        }

        public ActionResult Delete(int id = 0)
        {
            StudentClass user = db.GetById(id);
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
