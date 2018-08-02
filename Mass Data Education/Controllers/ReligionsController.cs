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
    public class ReligionsController : Controller
    {

        RepReligions db = new RepReligions();

        public ActionResult Index()
        {
            var data = db.GetAll();
            return View(data.ToList());
        }

        public ActionResult Details(int id = 0)
        {
            Religion Religion  = db.GetById(id);
            if (Religion == null)
            {
                return HttpNotFound();
            }
            return View(Religion);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Deleted")] Religion Religion)
        {
            if (ModelState.IsValid)
            {
                db.Add(Religion);
                return RedirectToAction("Index");
            }

            return View(Religion);
        }

        public ActionResult Edit(int id = 0)
        {
            Religion user = db.GetById(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Deleted")] Religion Religion)
        {
            if (ModelState.IsValid)
            {
                db.Update(Religion);
                return RedirectToAction("Index");
            }
            return View(Religion);
        }

        public ActionResult Delete(int id = 0)
        {
            Religion user = db.GetById(id);
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
