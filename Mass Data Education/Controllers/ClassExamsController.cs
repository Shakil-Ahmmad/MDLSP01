using System;
using System.Data.Entity;
using System.Linq;
using System.Web.Mvc;
using Mass_Data_Education.Models;
using Mass_Data_Education.Repository;
using System.Web.Security;

namespace Mass_Data_Education.Controllers
{
    public class ClassExamsController : Controller
    {
        RepClassExams rep = new RepClassExams();
        RepClasses repClasses = new RepClasses();
        RepExamNames repExamNames = new RepExamNames();
        MassDataEducationEntities db = new MassDataEducationEntities();
        
        public ActionResult Index()
        {
            var data = rep.GetAll();
            return View(data.ToList());
        }

        public ActionResult Details(int id = 0)
        {
            ClassExams ClassExams = rep.GetById(id);
            if (ClassExams == null)
            {
                return HttpNotFound();
            }
            return View(ClassExams);
        }

        public ActionResult Create()
        {
            ViewBag.ClassID = new SelectList(repClasses.GetAll(), "Id", "Name");
            ViewBag.ExamNamesID = new SelectList(repExamNames.GetAll(), "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ClassID,ExamNamesID,TotalMarks")] ClassExams ClassExams)
        {
            if (ModelState.IsValid)
            {
                if (rep.CheckIfExists(ClassExams.ClassID, ClassExams.ExamNamesID))
                {
                    ModelState.AddModelError(string.Empty, "Exam Already Exists");
                    ViewBag.ClassID = new SelectList(repClasses.GetAll(), "Id", "Name");
                    ViewBag.ExamNamesID = new SelectList(repExamNames.GetAll(), "Id", "Name");
                    return View(ClassExams);
                }
                rep.Add(ClassExams);
                return RedirectToAction("Index");
            }
            ViewBag.ClassID = new SelectList(repClasses.GetAll(), "Id", "Name");
            ViewBag.ExamNamesID = new SelectList(repExamNames.GetAll(), "Id", "Name");

            return View(ClassExams);
        }

        public ActionResult Edit(int id = 0)
        {
            var instuteID = Convert.ToInt32(Membership.GetUser().PasswordQuestion);
            ClassExams classobj = rep.GetById(id);
            if (classobj == null || Convert.ToInt32(classobj.InstituteID) != instuteID || classobj.Deleted == true)
            {
                return HttpNotFound();
            }
            return View(classobj);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,TotalMarks")] ClassExams ClassExams)
        {
            if (ModelState.IsValid)
            {

                var instuteID = Convert.ToInt32(Membership.GetUser().PasswordQuestion);
                ClassExams Exams = db.ClassExams.Find(ClassExams.Id);
                if (Exams == null || Convert.ToInt32(Exams.InstituteID) != instuteID || Exams.Deleted == true)
                {
                    return HttpNotFound();
                }
                if (!rep.CheckIfExists(Exams.ClassID, Exams.ExamNamesID))
                {
                    ModelState.AddModelError(string.Empty, "Data Doesn't Exists");
                    return View(ClassExams);
                }
                Exams.TotalMarks = ClassExams.TotalMarks;
                db.Entry(Exams).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(ClassExams);
        }

        public ActionResult Delete(int id = 0)
        {
            var instuteID = Convert.ToInt32(Membership.GetUser().PasswordQuestion);
            ClassExams classobj = rep.GetById(id);
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
            ClassExams classobj = rep.GetById(id);
            if (classobj == null || Convert.ToInt32(classobj.InstituteID) != instuteID || classobj.Deleted == true)
            {
                return HttpNotFound();
            }
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
