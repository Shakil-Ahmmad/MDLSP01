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
using System.Web.Security;

namespace Mass_Data_Education.Controllers
{
    public class GroupsController : Controller
    {
        RepGroups db = new RepGroups();

        public ActionResult Index()
        {
            var data = db.GetAll();
            return View(data.ToList());
        }

        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name")] Group Group)
        {
            if (ModelState.IsValid)
            {
                var instuteID = Convert.ToInt32(Membership.GetUser().PasswordQuestion);
                Group.InstituteID = instuteID;
                db.Add(Group);
                return RedirectToAction("Index");
            }

            return View(Group);
        }

        public ActionResult Edit(int id = 0)
        {
            var instuteID = Convert.ToInt32(Membership.GetUser().PasswordQuestion);
            Group Groupobj = db.GetById(id);
            if (Groupobj == null || Convert.ToInt32(Groupobj.InstituteID) != instuteID || Groupobj.Deleted == true)
            {
                return HttpNotFound();
            }
            return View(Groupobj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Name")] Group Group)
        {
            if (ModelState.IsValid)
            {
                var instuteID = Convert.ToInt32(Membership.GetUser().PasswordQuestion);
                Group Groupobj = db.GetById(Group.Id);
                if (Groupobj == null || Convert.ToInt32(Groupobj.InstituteID) != instuteID || Groupobj.Deleted == true)
                {
                    return HttpNotFound();
                }

                db.Update(Group);
                return RedirectToAction("Index");
            }
            return View(Group);
        }

        public ActionResult Delete(int id = 0)
        {
            var instuteID = Convert.ToInt32(Membership.GetUser().PasswordQuestion);
            Group Groupobj = db.GetById(id);
            if (Groupobj == null || Convert.ToInt32(Groupobj.InstituteID) != instuteID || Groupobj.Deleted == true)
            {
                return HttpNotFound();
            }
            return View(Groupobj);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var instuteID = Convert.ToInt32(Membership.GetUser().PasswordQuestion);
            Group Groupobj = db.GetById(id);
            if (Groupobj == null || Convert.ToInt32(Groupobj.InstituteID) != instuteID || Groupobj.Deleted == true)
            {
                return HttpNotFound();
            }

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
