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
    public class PaymantNamesController : Controller
    {


       RepPaymantNames db = new RepPaymantNames();

        public ActionResult Index()
        {
            var data = db.GetAll();
            return View(data.ToList());
        }

        public ActionResult Details(int id = 0)
        {
            PaymantNames PaymantNames = db.GetById(id);
            if (PaymantNames == null)
            {
                return HttpNotFound();
            }
            return View(PaymantNames);
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name")] PaymantNames PaymantNames)
        {
            if (ModelState.IsValid)
            {
                db.Add(PaymantNames);
                return RedirectToAction("Index");
            }

            return View(PaymantNames);
        }

        public ActionResult Edit(int id = 0)
        {
            PaymantNames user = db.GetById(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Name")] PaymantNames PaymantNames)
        {
            if (ModelState.IsValid)
            {
                db.Update(PaymantNames);
                return RedirectToAction("Index");
            }
            return View(PaymantNames);
        }

        public ActionResult Delete(int id = 0)
        {
            PaymantNames user = db.GetById(id);
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
