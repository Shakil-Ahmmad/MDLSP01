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
    public class SubjectNamesController : Controller
    {



        RepSubjectName db = new RepSubjectName();

        public ActionResult Index()
        {
            var data = db.GetAll();
            return View(data.ToList());
        }

        public ActionResult Details(int id = 0)
        {
            SubjectNames SubjectNames = db.GetById(id);
            if (SubjectNames == null)
            {
                return HttpNotFound();
            }
            return View(SubjectNames);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name")] SubjectNames SubjectNames)
        {
            if (ModelState.IsValid)
            {
                db.Add(SubjectNames);
                return RedirectToAction("Index");
            }

            return View(SubjectNames);
        }

        public ActionResult Edit(int id = 0)
        {
            SubjectNames user = db.GetById(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] SubjectNames SubjectNames)
        {
            if (ModelState.IsValid)
            {
                db.Update(SubjectNames);
                return RedirectToAction("Index");
            }
            return View(SubjectNames);
        }

        public ActionResult Delete(int id = 0)
        {
            SubjectNames user = db.GetById(id);
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
