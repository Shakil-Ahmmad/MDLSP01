using System;
using System.Data;
using System.Linq;
using System.Web.Mvc;
using System.Web.Security;
using System.Collections.Generic;
using Mass_Data_Education.Models;
using Mass_Data_Education.Repository;
using Mass_Data_Education.Models.ViewModel;

namespace Mass_Data_Education.Controllers
{
    public class ClassSubjectsController : Controller
    {
        RepClassSubjects rep = new RepClassSubjects();
        MassDataEducationEntities db = new MassDataEducationEntities();

        public ActionResult Index()
        {
            var data = rep.GetAll();
            return View(data.ToList());
        }

        public ActionResult Details(int id = 0)
        {
            var instuteID = Convert.ToInt32(Membership.GetUser().PasswordQuestion);

            ClassSubject subject = rep.GetById(id);
            if (subject == null || subject.Deleted == true || subject.InstituteID != instuteID)
            {
                return HttpNotFound();
            }
            var data = db.Class.Where(x => x.Deleted == false).Where(x => x.InstituteID == instuteID);
            ViewBag.ClassId = new SelectList(data, "Id", "Name");

            var classSubject = new ClassSubjectVM()
            {
                ClassName = subject.Class.Name,
                ClassId = subject.ClassId,
                Id = subject.Id,
                SubjectNames = subject.SubjectNames
            };
            classSubject.SubjectBooks = subject.SubjectBook.ToList();

            return View(classSubject);
        }

        public ActionResult Create()
        {
            var instuteID = Convert.ToInt32(Membership.GetUser().PasswordQuestion);
            var data = db.Class.Where(x => x.Deleted == false).Where(x => x.InstituteID == instuteID);
            ViewBag.ClassId = new SelectList(data, "Id", "Name");

            var ClassSubject = new ClassSubjectVM()
            {
                SubjectBooks = new List<SubjectBook>()
            };

            return View(ClassSubject);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ClassSubjectVM ClassSubject)
        {
            if (ModelState.IsValid)
            {
                rep.Add(ClassSubject);
                return RedirectToAction("Index");
            }

            var instuteID = Convert.ToInt32(Membership.GetUser().PasswordQuestion);
            var data = db.Class.Where(x => x.Deleted == false).Where(x => x.InstituteID == instuteID);
            ViewBag.ClassId = new SelectList(data, "Id", "Name");
            return View(ClassSubject);
        }

        public ActionResult Edit(int id = 0)
        {
            var instuteID = Convert.ToInt32(Membership.GetUser().PasswordQuestion);

            ClassSubject subject = rep.GetById(id);
            if (subject == null || subject.Deleted == true || subject.InstituteID != instuteID)
            {
                return HttpNotFound();
            }
            var data = db.Class.Where(x => x.Deleted == false).Where(x => x.InstituteID == instuteID);
            ViewBag.ClassId = new SelectList(data, "Id", "Name", subject.ClassId);
            
            var classSubject = new ClassSubjectVM()
            {
                ClassId = subject.ClassId,
                Id = subject.Id,
                SubjectNames = subject.SubjectNames
            };
            classSubject.SubjectBooks = subject.SubjectBook.ToList();

            return View(classSubject);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ClassSubjectVM ClassSubject)
        {
            var instuteID = Convert.ToInt32(Membership.GetUser().PasswordQuestion);
            ClassSubject subject = rep.GetById(ClassSubject.Id);
            if (subject == null || subject.Deleted == true || subject.InstituteID != instuteID)
            {
                return HttpNotFound();
            }

            if (ModelState.IsValid)
            {
                rep.Update(ClassSubject);
                return RedirectToAction("Index");
            }
            var data = db.Class.Where(x => x.Deleted == false).Where(x => x.InstituteID == instuteID);
            ViewBag.ClassId = new SelectList(data, "Id", "Name");
            return View(ClassSubject);
        }

        public ActionResult Delete(int id = 0)
        {
            var instuteID = Convert.ToInt32(Membership.GetUser().PasswordQuestion);

            ClassSubject subject = rep.GetById(id);
            if (subject == null || subject.Deleted == true || subject.InstituteID != instuteID)
            {
                return HttpNotFound();
            }
            var data = db.Class.Where(x => x.Deleted == false).Where(x => x.InstituteID == instuteID);
            ViewBag.ClassId = new SelectList(data, "Id", "Name");

            var classSubject = new ClassSubjectVM()
            {
                ClassName = subject.Class.Name,
                ClassId = subject.ClassId,
                Id = subject.Id,
                SubjectNames = subject.SubjectNames
            };
            classSubject.SubjectBooks = subject.SubjectBook.ToList();

            return View(classSubject);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int Id)
        {
            var instuteID = Convert.ToInt32(Membership.GetUser().PasswordQuestion);

            ClassSubject subject = rep.GetById(Id);
            if (subject == null || subject.Deleted == true || subject.InstituteID != instuteID)
            {
                return HttpNotFound();
            }
            rep.Delete(Id);
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
