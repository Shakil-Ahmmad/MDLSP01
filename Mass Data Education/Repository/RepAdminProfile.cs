using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mass_Data_Education.Models;

namespace Mass_Data_Education.Repository
{
    public class RepAdminProfile 
    {
        Shared<Person> rep = new Shared<Person>();
        MassDataEducationEntities db = new MassDataEducationEntities();
        public IEnumerable<Person> GetAll()
        {
            var data = db.Person.Where(x => x.Deleted == false).Where(x => x.Type == "Admin").ToList();
            return data;
        }
        public Person GetById(string id)
        {
            var data = rep.GetById(id);
            if (data.Deleted)
                return null;
            return data;
        }
        public Person Add(Person person)
        {
            using (var Transaction = db.Database.BeginTransaction())
            {
                try
                {
                    db.Person.Add(person);
                    db.SaveChanges();

                    var institute = new Institute()
                    {
                        Name = "Institute Name",
                        PersonID = person.Id
                    };

                    db.Institute.Add(institute);
                    db.SaveChanges();

                    person.InstituteID = institute.Id;
                    db.Entry(person).Property(x => x.InstituteID).IsModified = true;
                    db.SaveChanges();

                    Transaction.Commit();
                }
                catch (Exception ex)
                {
                    Transaction.Rollback();
                }
            }
            return person;
        }
        public void Update(Person entity)
        {
            //db.Person.Attach(entity);
            //db.Entry(entity).Property(x => x.Id).IsModified = false;
            //db.Entry(entity).Property(x => x.Date).IsModified = false;
            //db.Entry(entity).Property(x => x.Type).IsModified = false;
            //db.Entry(entity).Property(x => x.Deleted).IsModified = false;
            //db.Entry(entity).Property(x => x.InstituteID).IsModified = false;
            //db.Entry(entity).Property(x => x.DesignationID).IsModified = false;
            //db.Entry(entity).Property(x => x.Image).IsModified = (entity.Image != null) ? true : false;
            //db.SaveChanges();
            if(entity.Image != null)
                rep.Update(entity, x => x.Name, x => x.Mobile, x => x.FathersName, x => x.MothersName, x => x.GurdiansNumber, x => x.Email, x => x.GenderID, x => x.BloodGroupID, x => x.ReligionID, x => x.Password, x => x.Image );
            else
                rep.Update(entity, x => x.Name, x => x.Mobile, x => x.FathersName, x => x.MothersName, x => x.GurdiansNumber, x => x.Email, x => x.GenderID, x => x.BloodGroupID, x => x.ReligionID, x => x.Password);
        }
        public void Delete(string id)
        {
            rep.Delete(id);
        }
        public void Dispose()
        {
            rep.Dispose();
        }

        internal void UpdateInstitute(Person entity)
        {

            db.Person.Attach(entity);
            db.Entry(entity).Property(x => x.InstituteID).IsModified = false;
            db.SaveChanges();
        }
    }
}