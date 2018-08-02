using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mass_Data_Education.Models;

namespace Mass_Data_Education.Repository
{
    public class RepStudentProfile
    {


        Shared<Person> rep = new Shared<Person>();
        MassDataEducationEntities db = new MassDataEducationEntities();
        public IEnumerable<Person> GetAll()
        {
            //var users = hc.Users.Select(x => new { x.address, x.name, x.contact_number, x.email, x.password }).ToList();
            return rep.GetAll(c => c.Deleted == false);
        }
        public Person GetById(int id)
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
            rep.Update(entity);
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