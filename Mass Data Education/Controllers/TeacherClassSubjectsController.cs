﻿using System;
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
    public class TeacherClassSubjectsController : Controller
    {

        RepTeacherClassSubject db = new RepTeacherClassSubject();

        public ActionResult Index()
        {
            var data = db.GetAll();
            return View(data.ToList());
        }

        public ActionResult Details(int id = 0)
        {
            TeacherClassSubject TeacherClassSubject = db.GetById(id);
            if (TeacherClassSubject == null)
            {
                return HttpNotFound();
            }
            return View(TeacherClassSubject);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,InstituteID,PersonID,ClassSubjectID,Deleted")] TeacherClassSubject TeacherClassSubject)
        {
            if (ModelState.IsValid)
            {
                db.Add(TeacherClassSubject);
                return RedirectToAction("Index");
            }

            return View(TeacherClassSubject);
        }

        public ActionResult Edit(int id = 0)
        {
            TeacherClassSubject user = db.GetById(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,InstituteID,PersonID,ClassSubjectID,Deleted")] TeacherClassSubject TeacherClassSubject)
        {
            if (ModelState.IsValid)
            {
                db.Update(TeacherClassSubject);
                return RedirectToAction("Index");
            }
            return View(TeacherClassSubject);
        }

        public ActionResult Delete(int id = 0)
        {
            TeacherClassSubject user = db.GetById(id);
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