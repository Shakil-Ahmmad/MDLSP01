using System;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mass_Data_Education.Models;
using Mass_Data_Education.Repository;
using System.Web.Security;
using System.IO;
using Mass_Data_Education.CustomAuthentication;

namespace Mass_Data_Education.Controllers
{
    [CustomAuthorize(Roles = "SuperAdmin,Admin")]
    public class AccountProfileController : Controller
    {
        RepAccaountProfile rep = new RepAccaountProfile();
        MassDataEducationEntities db = new MassDataEducationEntities();

        public ActionResult Index()
        {
            var data = rep.GetAll();
            return View(data);
        }

        public ActionResult Details(string id)
        {
            var instuteID = Convert.ToInt32(Membership.GetUser().PasswordQuestion);
            Person Person = rep.GetById(id);
            if (Person == null || Convert.ToInt32(Person.InstituteID) != instuteID || Person.Deleted == true)
            {
                return HttpNotFound();
            }
            return View(Person);
        }

        public ActionResult Create()
        {
            ViewBag.GenderID = new SelectList(db.Gender.Where(x => x.Deleted == false), "Id", "Name");
            ViewBag.BloodGroupID = new SelectList(db.BloodGroup.Where(x => x.Deleted == false), "Id", "Name");
            ViewBag.ReligionID = new SelectList(db.Religion.Where(x => x.Deleted == false), "Id", "Name");
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "Id,Name,Mobile,Email,FathersName,MothersName,GurdiansNumber,GenderID,BloodGroupID,ReligionID,Password")] Person Person, HttpPostedFileBase PersonImage)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var instuteID = Convert.ToInt32(Membership.GetUser().PasswordQuestion);
                    if (PersonImage != null)
                    {
                        var fileName = Path.GetFileName(PersonImage.FileName);
                        string fileExtension = Path.GetExtension(fileName);
                        string baseImage = Guid.NewGuid() + "." + fileExtension;
                        string pathString = Path.Combine(Server.MapPath("~/Images/PersonImage"));
                        if (!Directory.Exists(pathString)) Directory.CreateDirectory(pathString);
                        var uploadpath = string.Format("{0}\\{1}", pathString, baseImage);
                        PersonImage.SaveAs(uploadpath);
                        Person.Image = baseImage;
                    }

                    Person.InstituteID = instuteID;
                    Person.Date = DateTime.Now;
                    Person.Type = "Accountant";
                    rep.Add(Person);

                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {

                }
            }
            ViewBag.GenderID = new SelectList(db.Gender.Where(x => x.Deleted == false), "Id", "Name", Person.GenderID);
            ViewBag.BloodGroupID = new SelectList(db.BloodGroup.Where(x => x.Deleted == false), "Id", "Name", Person.BloodGroupID);
            ViewBag.ReligionID = new SelectList(db.Religion.Where(x => x.Deleted == false), "Id", "Name", Person.ReligionID);
            return View(Person);
        }

        public ActionResult Edit(string id)
        {
            var instuteID = Convert.ToInt32(Membership.GetUser().PasswordQuestion);
            Person Person = rep.GetById(id);
            if (Person == null || Convert.ToInt32(Person.InstituteID) != instuteID || Person.Deleted == true)
            {
                return HttpNotFound();
            }
            ViewBag.GenderID = new SelectList(db.Gender.Where(x => x.Deleted == false), "Id", "Name", Person.GenderID);
            ViewBag.BloodGroupID = new SelectList(db.BloodGroup.Where(x => x.Deleted == false), "Id", "Name", Person.BloodGroupID);
            ViewBag.ReligionID = new SelectList(db.Religion.Where(x => x.Deleted == false), "Id", "Name", Person.ReligionID);
            return View(Person);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Mobile,Email,FathersName,MothersName,GurdiansNumber,GenderID,BloodGroupID,ReligionID,Password")] Person Person, HttpPostedFileBase PersonImage)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    if (PersonImage != null)
                    {
                        var filePath = Server.MapPath("~/Images/PersonImage/" + db.Person.Find(Person.Id).Image);
                        if (System.IO.File.Exists(filePath))
                        {
                            System.IO.File.Delete(filePath);
                        }

                        var fileName = Path.GetFileName(PersonImage.FileName);
                        string fileExtension = Path.GetExtension(fileName);
                        string baseImage = Guid.NewGuid() + fileExtension;
                        string pathString = Path.Combine(Server.MapPath("~/Images/PersonImage"));
                        if (!Directory.Exists(pathString)) Directory.CreateDirectory(pathString);
                        var uploadpath = string.Format("{0}\\{1}", pathString, baseImage);
                        PersonImage.SaveAs(uploadpath);
                        Person.Image = baseImage;
                    }
                    Person.Type = "Accountant";
                    rep.Update(Person);
                    return RedirectToAction("Index");
                }
                catch (Exception ex)
                {

                }
            }
            ViewBag.GenderID = new SelectList(db.Gender.Where(x => x.Deleted == false), "Id", "Name", Person.GenderID);
            ViewBag.BloodGroupID = new SelectList(db.BloodGroup.Where(x => x.Deleted == false), "Id", "Name", Person.BloodGroupID);
            ViewBag.ReligionID = new SelectList(db.Religion.Where(x => x.Deleted == false), "Id", "Name", Person.ReligionID);
            return View(Person);
        }

        public ActionResult Delete(string id)
        {
            var instuteID = Convert.ToInt32(Membership.GetUser().PasswordQuestion);
            Person Person = rep.GetById(id);
            if (Person == null || Convert.ToInt32(Person.InstituteID) != instuteID || Person.Deleted == true)
            {
                return HttpNotFound();
            }
            return View(Person);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            var instuteID = Convert.ToInt32(Membership.GetUser().PasswordQuestion);
            Person Person = rep.GetById(id);
            if (Person == null || Convert.ToInt32(Person.InstituteID) != instuteID || Person.Deleted == true)
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
