using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mass_Data_Education.Models;
namespace Mass_Data_Education.Repository
{
    public class RepDesignations
    {

        Shared<Designation> rep = new Shared<Designation>();

        MassDataEducationEntities db = new MassDataEducationEntities();
        public IEnumerable<Designation> GetAll()
        {
            //var users = hc.Users.Select(x => new { x.address, x.name, x.contact_number, x.email, x.password }).ToList();
            return rep.GetAll(c => c.Deleted == false);
        }
        public Designation GetById(int id)
        {
            var data = rep.GetById(id);
            if (data.Deleted)
                return null;
            return data;
        }
        public Designation Add(Designation entity)
        {
            return rep.Add(entity);
        }
        public void Update(Designation entity)
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