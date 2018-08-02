using System.Linq;
using System.Web.Mvc;
using Mass_Data_Education.Models;
using Mass_Data_Education.Repository;

namespace Mass_Data_Education.Controllers
{
    public class GendersController : Controller
    {
        RepGender db = new RepGender();
        
        public ActionResult Index()
        {
            var data = db.GetAll();
            return View(data.ToList());
        }
        
        public ActionResult Details(int id = 0)
        {
            Gender Gender = db.GetById(id);
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
        public ActionResult Create([Bind(Include = "Name")] Gender Gender)
        {
            if (ModelState.IsValid)
            {
                db.Add(Gender);
                return RedirectToAction("Index");
            }

            return View(Gender);
        }
        
        public ActionResult Edit(int id = 0)
        {
            Gender user = db.GetById(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }
        
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "id,Name")] Gender Gender)
        {
            if (ModelState.IsValid)
            {
                db.Update(Gender);
                return RedirectToAction("Index");
            }
            return View(Gender);
        }
        
        public ActionResult Delete(int id = 0)
        {
            Gender user = db.GetById(id);
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
