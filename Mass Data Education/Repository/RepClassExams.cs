using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mass_Data_Education.Models;
using System.Web.Security;

namespace Mass_Data_Education.Repository
{
    public class RepClassExams
    {
        Shared<ClassExams> rep = new Shared<ClassExams>();

        MassDataEducationEntities db = new MassDataEducationEntities();
        public IEnumerable<ClassExams> GetAll()
        {
            var instuteID = Convert.ToInt32(Membership.GetUser().PasswordQuestion);
            var data = db.ClassExams.Where(x => x.Deleted == false).Where(x => x.InstituteID == instuteID).ToList();
            return data;
        }
        public ClassExams GetById(int id)
        {
            var data = rep.GetById(id);
            if (data.Deleted)
                return null;
            return data;
        }
        public bool CheckIfExists(int ClassID, int ExamNamesID)
        {
            var instuteID = Convert.ToInt32(Membership.GetUser().PasswordQuestion);
            var data = db.ClassExams.Where(x => x.ClassID == ClassID && x.ExamNamesID == ExamNamesID && x.InstituteID == instuteID).FirstOrDefault();
            return (data == null) ? false : true;
        }
        public ClassExams Add(ClassExams entity)
        {
            var instuteID = Convert.ToInt32(Membership.GetUser().PasswordQuestion);
            entity.InstituteID = instuteID;
            return rep.Add(entity);
        }
        public void Update(ClassExams entity)
        {
            db.ClassExams.Attach(entity);
            db.Entry(entity).Property(x => x.TotalMarks).IsModified = true;
            db.SaveChanges();
        }
        public void Delete(int id)
        {
            rep.Delete(id);
        }
        public void Dispose()
        {
            rep.Dispose();
        }

    }
}