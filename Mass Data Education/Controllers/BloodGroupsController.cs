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
    public class BloodGroupsController : Controller
    {
        RepBloodGroup db = new RepBloodGroup();

        public ActionResult Index()
        {
            var data = db.GetAll();
            return View(data.ToList());
        }

        public ActionResult Details(int id = 0)
        {
            BloodGroup Gender = db.GetById(id);
            if (Gender == null)
            {
                return HttpNotFound();
            }
            return View(Gender);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name")] BloodGroup BloodGroup )
        {
            if (ModelState.IsValid)
            {
                db.Add(BloodGroup);
                return RedirectToAction("Index");
            }

            return View(BloodGroup);
        }

        public ActionResult Edit(int id = 0)
        {
            BloodGroup user = db.GetById(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Name")] BloodGroup BloodGroup)
        {
            if (ModelState.IsValid)
            {
                db.Update(BloodGroup);
                return RedirectToAction("Index");
            }
            return View(BloodGroup);
        }

        public ActionResult Delete(int id = 0)
        {
            BloodGroup user = db.GetById(id);
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
