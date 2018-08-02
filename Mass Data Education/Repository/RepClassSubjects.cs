using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mass_Data_Education.Models;
using Mass_Data_Education.Models.ViewModel;
using System.Web.Security;

namespace Mass_Data_Education.Repository
{
    public class RepClassSubjects
    {
        Shared<ClassSubject> rep = new Shared<ClassSubject>();
        MassDataEducationEntities db = new MassDataEducationEntities();

        public IEnumerable<ClassSubjectVM> GetAll()
        {
            var instuteID = Convert.ToInt32(Membership.GetUser().PasswordQuestion);
            var data = db.ClassSubject.Where(x => x.Deleted == false).Where(x => x.InstituteID == instuteID).Select(x => new ClassSubjectVM()
            {
                Id = x.Id,
                ClassId = x.ClassId,
                SubjectNames = x.SubjectNames
            }).ToList();

            foreach (var item in data)
            {
                item.SubjectBooks = db.SubjectBook.Where(x => x.Deleted == false).Where(x => x.ClassSubjectID == item.Id).ToList();
                item.ClassName = db.Class.Find(item.ClassId).Name;
            }
            
            return data;
        }
        public ClassSubject GetById(int id)
        {
            var data = rep.GetById(id);
            if (data.Deleted)
                return null;
            return data;
        }
        public ClassSubject Add(ClassSubjectVM entity)
        {
            var instuteID = Convert.ToInt32(Membership.GetUser().PasswordQuestion);

            var classsubject = new ClassSubject()
            {
                InstituteID = instuteID,
                ClassId = entity.ClassId,
                SubjectNames = entity.SubjectNames
            };
            using (var Transaction = db.Database.BeginTransaction())
            {
                try
                {
                    db.ClassSubject.Add(classsubject);
                    db.SaveChanges();

                    if (entity.SubjectBooks != null)
                    {
                        foreach (var item in entity.SubjectBooks)
                        {
                            if (!string.IsNullOrWhiteSpace(item.Name))
                            {
                                item.ClassSubjectID = classsubject.Id;
                                db.SubjectBook.Add(item);
                            }
                        }
                        db.SaveChanges();
                    }
                    Transaction.Commit();
                }
                catch (Exception ex)
                {
                    Transaction.Rollback();
                }
            }
            
            return classsubject;
        }
        public ClassSubject Update(ClassSubjectVM entity)
        {
            var instuteID = Convert.ToInt32(Membership.GetUser().PasswordQuestion);
            var classsubject = db.ClassSubject.Find(entity.Id);
            classsubject.SubjectNames = entity.SubjectNames;
            db.Entry(classsubject).Property(x => x.SubjectNames).IsModified = true;

            using (var Transaction = db.Database.BeginTransaction())
            {
                try
                {
                    db.SaveChanges();
                    db.Database.ExecuteSqlCommand("DELETE FROM SubjectBook WHERE ClassSubjectID = " + classsubject.Id);
                    if (entity.SubjectBooks != null)
                    {
                        foreach (var item in entity.SubjectBooks)
                        {
                            if (!string.IsNullOrWhiteSpace(item.Name))
                            {
                                item.ClassSubjectID = classsubject.Id;
                                db.SubjectBook.Add(item);
                            }
                        }
                        db.SaveChanges();
                    }
                    db.SaveChanges();
                    Transaction.Commit();
                }
                catch (Exception ex)
                {
                    Transaction.Rollback();
                }
            }

            return classsubject;
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