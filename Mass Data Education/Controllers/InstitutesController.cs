using System.Web.Mvc;
using Mass_Data_Education.Models;
using Mass_Data_Education.Repository;
using System.Web;
using System.IO;
using System;
using System.Web.Security;

namespace Mass_Data_Education.Controllers
{
    public class InstitutesController : Controller
    {
        MassDataEducationEntities db = new MassDataEducationEntities();
        RepInstitute rep = new RepInstitute();

        public ActionResult Details(int id = 0)
        {
            var personID = Membership.GetUser().ProviderUserKey.ToString();
            var person = db.Person.Find(personID);

            Institute Institute = rep.GetById(id);
            if (person.Type == "Admin")
            {
                Institute = rep.GetById(Convert.ToInt32(person.InstituteID));
            }

            if (Institute == null)
            {
                return HttpNotFound();
            }
            return View(Institute);
        }

        public ActionResult Edit(int id = 0)
        {
            var personID = Membership.GetUser().ProviderUserKey.ToString();
            var person = db.Person.Find(personID);

            Institute Institute = rep.GetById(id);
            if (person.Type == "Admin")
            {
                Institute = rep.GetById(Convert.ToInt32(person.InstituteID));
            }

            if (Institute == null)
            {
                return HttpNotFound();
            }
            return View(Institute);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Name,Address,Email,Phone")] Institute Institute, HttpPostedFileBase InstituteLogo)
        {
            if (ModelState.IsValid)
            {

                if (InstituteLogo != null)
                {
                    var filePath = Server.MapPath("~/Images/InstituteLogo/" + db.Institute.Find(Institute.Id).Logo);
                    if (System.IO.File.Exists(filePath))
                    {
                        System.IO.File.Delete(filePath);
                    }

                    var fileName = Path.GetFileName(InstituteLogo.FileName);
                    string fileExtension = Path.GetExtension(fileName);
                    string baseImage = Guid.NewGuid() + fileExtension;
                    string pathString = Path.Combine(Server.MapPath("~/Images/InstituteLogo"));
                    if (!Directory.Exists(pathString)) Directory.CreateDirectory(pathString);
                    var uploadpath = string.Format("{0}\\{1}", pathString, baseImage);
                    InstituteLogo.SaveAs(uploadpath);
                    Institute.Logo = baseImage;
                }
                var personID = Membership.GetUser().ProviderUserKey.ToString();
                var person = db.Person.Find(personID);
                Institute.Id = Convert.ToInt32(person.InstituteID);

                rep.Update(Institute);
                return RedirectToAction("Details", new { id = Institute.Id });
            }
            return View(Institute);
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
