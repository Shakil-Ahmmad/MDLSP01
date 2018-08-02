using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mass_Data_Education.Models;

namespace Mass_Data_Education.Repository
{
    public class RepInstitute
    {
        Shared<Institute> rep = new Shared<Institute>();
        MassDataEducationEntities db = new MassDataEducationEntities();
        public IEnumerable<Institute> GetAll()
        {
            //var users = hc.Users.Select(x => new { x.address, x.name, x.contact_number, x.email, x.password }).ToList();
            return rep.GetAll(c => c.Deleted == false);
        }
        public Institute GetById(int id)
        {
            var data = rep.GetById(id);
            if (data.Deleted)
                return null;
            return data;
        }
        public Institute Add(Institute entity)
        {
            return rep.Add(entity);
        }
        public void Update(Institute entity)
        {
            db.Institute.Attach(entity);
            db.Entry(entity).Property(x => x.Address).IsModified = true;
            db.Entry(entity).Property(x => x.Email).IsModified = true;
            db.Entry(entity).Property(x => x.Name).IsModified = true;
            db.Entry(entity).Property(x => x.Phone).IsModified = true;
            if (entity.Logo != null)
                db.Entry(entity).Property(x => x.Logo).IsModified = true;
            db.SaveChanges();
            //if (entity.Logo == null)
            //    rep.Update(entity, x => x.Address, x => x.Email, x => x.Name, x => x.Phone);
            //else
            //    rep.Update(entity, x => x.Address, x => x.Email, x => x.Name, x => x.Phone, x => x.Logo);

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