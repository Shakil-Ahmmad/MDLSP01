using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mass_Data_Education.Models;
using System.Web.Security;

namespace Mass_Data_Education.Repository
{
    public class RepAccaountProfile
    {
        Shared<Person> rep = new Shared<Person>();
        MassDataEducationEntities db = new MassDataEducationEntities();
        public IEnumerable<Person> GetAll()
        {
            var InstituteID = Convert.ToInt32(Membership.GetUser().PasswordQuestion);
            var users = db.Person.Where(x => x.Deleted == false).Where(x => x.Type == "Accountant").Where(x => x.InstituteID == InstituteID).ToList();
            return users;
        }
        public Person GetById(string id)
        {
            var data = rep.GetById(id);
            if (data.Deleted)
                return null;
            return data;
        }
        public Person Add(Person entity)
        {
            return rep.Add(entity);
        }
        public void Update(Person entity)
        {
            if (entity.Image != null)
                rep.Update(entity, x => x.Name, x => x.Mobile, x => x.FathersName, x => x.MothersName, x => x.GurdiansNumber, x => x.Email, x => x.GenderID, x => x.BloodGroupID, x => x.ReligionID, x => x.Password, x => x.Image);
            else
                rep.Update(entity, x => x.Name, x => x.Mobile, x => x.FathersName, x => x.MothersName, x => x.GurdiansNumber, x => x.Email, x => x.GenderID, x => x.BloodGroupID, x => x.ReligionID, x => x.Password);
            //rep.Update(entity);
        }
        public void Delete(string id)
        {
            rep.Delete(id);
        }
        public void Dispose()
        {
            rep.Dispose();
        }
    }
}