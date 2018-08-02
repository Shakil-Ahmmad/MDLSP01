using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mass_Data_Education.Models;

namespace Mass_Data_Education.Repository
{
    public class RepReligions
    {
        Shared<Religion> rep = new Shared<Religion>();

        MassDataEducationEntities db = new MassDataEducationEntities();
        public IEnumerable<Religion> GetAll()
        {
            //var users = hc.Users.Select(x => new { x.address, x.name, x.contact_number, x.email, x.password }).ToList();
            return rep.GetAll(c => c.Deleted == false);
        }
        public Religion GetById(int id)
        {
            var data = rep.GetById(id);
            if (data.Deleted)
                return null;
            return data;
        }
        public Religion Add(Religion entity)
        {
            return rep.Add(entity);
        }
        public void Update(Religion entity)
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