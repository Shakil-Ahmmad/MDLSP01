using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Mass_Data_Education.Models;
namespace Mass_Data_Education.Repository
{
    public class RepSection
    {



        Shared<Section> rep = new Shared<Section>();

        MassDataEducationEntities db = new MassDataEducationEntities();
        public IEnumerable<Section> GetAll()
        {
            //var users = hc.Users.Select(x => new { x.address, x.name, x.contact_number, x.email, x.password }).ToList();
            return rep.GetAll(c => c.Deleted == false);
        }
        public Section GetById(int id)
        {
            var data = rep.GetById(id);
            if (data.Deleted)
                return null;
            return data;
        }
        public Section Add(Section entity)
        {
            return rep.Add(entity);
        }
        public void Update(Section entity)
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