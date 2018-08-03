using Mass_Data_Education.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Mass_Data_Education.Repository
{
    public class RepGroups
    {

        Shared<Group> rep = new Shared<Group>();
        MassDataEducationEntities db = new MassDataEducationEntities();
        public IEnumerable<Group> GetAll()
        {
            //var users = hc.Users.Select(x => new { x.address, x.name, x.contact_number, x.email, x.password }).ToList();
            return rep.GetAll(c => c.Deleted == false);
        }
        public Group GetById(int id)
        {
            var data = rep.GetById(id);
            if (data.Deleted)
                return null;
            return data;
        }
        public Group Add(Group entity)
        {
            return rep.Add(entity);
        }
        public void Update(Group entity)
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