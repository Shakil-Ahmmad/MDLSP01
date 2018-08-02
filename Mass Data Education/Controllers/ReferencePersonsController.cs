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
    public class ReferencePersonsController : Controller
    {


        RepReferencePersons db = new RepReferencePersons();

        public ActionResult Index()
        {
            var data = db.GetAll();
            return View(data.ToList());
        }

        public ActionResult Details(int id = 0)
        {
            ReferencePerson ReferencePerson = db.GetById(id);
            if (ReferencePerson == null)
            {
                return HttpNotFound();
            }
            return View(ReferencePerson);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,PhoneNo,Address,Deleted")] ReferencePerson ReferencePerson)
        {
            if (ModelState.IsValid)
            {
                db.Add(ReferencePerson);
                return RedirectToAction("Index");
            }

            return View(ReferencePerson);
        }

        public ActionResult Edit(int id = 0)
        {
            ReferencePerson user = db.GetById(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,PhoneNo,Address,Deleted")] ReferencePerson ReferencePerson)
        {
            if (ModelState.IsValid)
            {
                db.Update(ReferencePerson);
                return RedirectToAction("Index");
            }
            return View(ReferencePerson);
        }

        public ActionResult Delete(int id = 0)
        {
            ReferencePerson user = db.GetById(id);
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
