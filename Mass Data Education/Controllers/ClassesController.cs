using System;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using Mass_Data_Education.Models;
using Mass_Data_Education.Repository;
using Mass_Data_Education.CustomAuthentication;

namespace Mass_Data_Education.Controllers
{
    [CustomAuthorize(Roles = "SuperAdmin,Admin")]
    public class ClassesController : Controller
    {
        RepClasses db = new RepClasses();

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
        public ActionResult Create([Bind(Include = "Name")] Class Class)
        {
            if (ModelState.IsValid)
            {
                var instuteID = Convert.ToInt32(Membership.GetUser().PasswordQuestion);
                Class.InstituteID = instuteID;
                db.Add(Class);
                return RedirectToAction("Index");
            }

            return View(Class);
        }

        public ActionResult Edit(int id = 0)
        {
            var instuteID = Convert.ToInt32(Membership.GetUser().PasswordQuestion);
            Class classobj = db.GetById(id);
            if (classobj == null || Convert.ToInt32(classobj.InstituteID) != instuteID || classobj.Deleted == true)
            {
                return HttpNotFound();
            }
            return View(classobj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Name")] Class Class)
        {
            if (ModelState.IsValid)
            {
                var instuteID = Convert.ToInt32(Membership.GetUser().PasswordQuestion);
                Class classobj = db.GetById(Class.Id);
                if (classobj == null || Convert.ToInt32(classobj.InstituteID) != instuteID || classobj.Deleted == true)
                {
                    return HttpNotFound();
                }

                db.Update(Class);
                return RedirectToAction("Index");
            }
            return View(Class);
        }

        public ActionResult Delete(int id = 0)
        {
            var instuteID = Convert.ToInt32(Membership.GetUser().PasswordQuestion);
            Class classobj = db.GetById(id);
            if (classobj == null || Convert.ToInt32(classobj.InstituteID) != instuteID || classobj.Deleted == true)
            {
                return HttpNotFound();
            }
            return View(classobj);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var instuteID = Convert.ToInt32(Membership.GetUser().PasswordQuestion);
            Class classobj = db.GetById(id);
            if (classobj == null || Convert.ToInt32(classobj.InstituteID) != instuteID || classobj.Deleted == true)
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
