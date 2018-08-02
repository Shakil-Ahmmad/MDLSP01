using System;
using System.IO;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mass_Data_Education.Models;
using Mass_Data_Education.Repository;
using Mass_Data_Education.CustomAuthentication;

namespace Mass_Data_Education.Controllers
{
    [CustomAuthorize(Roles = "SuperAdmin")]
    public class AdminProfileController : Controller
    {
        RepAdminProfile rep = new RepAdminProfile();
        RepInstitute repins = new RepInstitute();
        MassDataEducationEntities db = new MassDataEducationEntities();

        public ActionResult Index()
        {
            var data = rep.GetAll();
            return View(data.ToList());
        }

        public ActionResult Details(string id)
        {
            Person Person = rep.GetById(id);
            if (Person == null)
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
        public ActionResult Create([Bind(Include = "Id,Name,Type,Mobile,Email,FathersName,MothersName,GurdiansNumber,GenderID,BloodGroupID,ReligionID,Image,Password")] Person Person, HttpPostedFileBase PersonImage)
        {
            if (ModelState.IsValid)
            {
                try
                {
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

                    Person.Date = DateTime.Now;
                    Person.Type = "Admin";
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
            Person Person = rep.GetById(id);
            if (Person == null || Person.Deleted == true)
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
        public ActionResult Edit([Bind(Include = "Id,Name,Type,Mobile,Email,FathersName,MothersName,GurdiansNumber,GenderID,BloodGroupID,ReligionID,Image,Password")] Person Person, HttpPostedFileBase PersonImage)
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

                    Person.Date = DateTime.Now;
                    Person.Type = "Admin";
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
            Person user = rep.GetById(id);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            rep.Delete(id);
            return RedirectToAction("Index");
        }

        [AllowAnonymous]
        public JsonResult IsIdExists(string Id, string Email)
        {
            if (Email != null)
            {
                var person = db.Person.Where(x => x.Email == Email).FirstOrDefault();
                if (person != null && person.Id == Id)
                {
                    return Json(true, JsonRequestBehavior.AllowGet);
                }
            }
            return Json(!db.Person.Any(x => x.Id == Id), JsonRequestBehavior.AllowGet);
        }


        [AllowAnonymous]
        public JsonResult IsEmailExists(string Email, string Id)
        {
            if (Id != null)
            {
                var person = db.Person.Where(x => x.Id == Id).FirstOrDefault();
                if (person != null && person.Email == Email)
                {
                    return Json(true, JsonRequestBehavior.AllowGet);
                }
            }
            return Json(!db.Person.Any(x => x.Email == Email), JsonRequestBehavior.AllowGet);
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
