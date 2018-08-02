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
    public class ResultsController : Controller
    {


        RepResults db = new RepResults();

        public ActionResult Index()
        {
            var data = db.GetAll();
            return View(data.ToList());
        }

        public ActionResult Details(int id = 0)
        {
            Result Result = db.GetById(id);
            if (Result == null)
            {
                return HttpNotFound();
            }
            return View(Result);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,PersonID,ClassID,InstituteID,ClassSubjectID,ClassExamsID,TotalMarks,GottenMarks,Grade,Deleted")] Result Result)
        {
            if (ModelState.IsValid)
            {
                db.Add(Result);
                return RedirectToAction("Index");
            }

            return View(Result);
        }

        public ActionResult Edit(int id = 0)
        {
            Result user = db.GetById(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,PersonID,ClassID,InstituteID,ClassSubjectID,ClassExamsID,TotalMarks,GottenMarks,Grade,Deleted")] Result Result)
        {
            if (ModelState.IsValid)
            {
                db.Update(Result);
                return RedirectToAction("Index");
            }
            return View(Result);
        }

        public ActionResult Delete(int id = 0)
        {
            Result user = db.GetById(id);
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
