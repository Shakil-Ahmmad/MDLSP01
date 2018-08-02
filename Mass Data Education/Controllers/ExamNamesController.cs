using System.Linq;
using System.Web.Mvc;
using Mass_Data_Education.Models;
using Mass_Data_Education.Repository;
using Mass_Data_Education.CustomAuthentication;

namespace Mass_Data_Education.Controllers
{
    [CustomAuthorize(Roles = "SuperAdmin")]
    public class ExamNamesController : Controller
    {
        RepExamNames rep = new RepExamNames();

        public ActionResult Index()
        {
            var data = rep.GetAll();
            return View(data.ToList());
        }
        
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Name")] ExamNames ExamNames)
        {
            if (ModelState.IsValid)
            {
                rep.Add(ExamNames);
                return RedirectToAction("Index");
            }

            return View(ExamNames);
        }

        public ActionResult Edit(int id = 0)
        {
            var user = rep.GetById(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name")] ExamNames ExamNames)
        {
            if (ModelState.IsValid)
            {
                rep.Update(ExamNames);
                return RedirectToAction("Index");
            }
            return View(ExamNames);
        }

        public ActionResult Delete(int id = 0)
        {
            ExamNames user = rep.GetById(id);
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
            rep.Delete(id);
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                rep.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}

        
