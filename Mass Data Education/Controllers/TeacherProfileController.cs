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
    public class TeacherProfileController : Controller
    {

        RepTeacherProfile db = new RepTeacherProfile();

        public ActionResult Index()
        {
            var data = db.GetAll();
            return View(data.ToList());
        }

        public ActionResult Details(int id = 0)
        {
            Person Person = db.GetById(id);
            if (Person == null)
            {
                return HttpNotFound();
            }
            return View(Person);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,InstituteID,Name,Type,Mobile,Email,FathersName,MothersName,GurdiansNumber,DesignationID,GenderID,BloodGroupID,ReligionID,Image,Date,Password,Deleted")] Person Person)
        {
            if (ModelState.IsValid)
            {
                db.Add(Person);
                return RedirectToAction("Index");
            }

            return View(Person);
        }

        public ActionResult Edit(int id = 0)
        {
            Person user = db.GetById(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,InstituteID,Name,Type,Mobile,Email,FathersName,MothersName,GurdiansNumber,DesignationID,GenderID,BloodGroupID,ReligionID,Image,Date,Password,Deleted")] Person Person)
        {
            if (ModelState.IsValid)
            {
                db.Update(Person);
                return RedirectToAction("Index");
            }
            return View(Person);
        }

        public ActionResult Delete(int id = 0)
        {
            Person user = db.GetById(id);
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
