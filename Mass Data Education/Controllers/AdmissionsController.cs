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
    public class AdmissionsController : Controller
    {
        RepAdmissions db = new RepAdmissions();

        public ActionResult Index()
        {
            var data = db.GetAll();
            return View(data.ToList());
        }

        public ActionResult Details(int id = 0)
        {
            Admission Admission = db.GetById(id);
            if (Admission == null)
            {
                return HttpNotFound();
            }
            return View(Admission);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name")] Admission Admission)
        {
            if (ModelState.IsValid)
            {
                db.Add(Admission);
                return RedirectToAction("Index");
            }

            return View(Admission);
        }

        public ActionResult Edit(int id = 0)
        {
            Admission user = db.GetById(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Name")] Admission Admission)
        {
            if (ModelState.IsValid)
            {
                db.Update(Admission);
                return RedirectToAction("Index");
            }
            return View(Admission);
        }

        public ActionResult Delete(int id = 0)
        {
            Admission user = db.GetById(id);
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
