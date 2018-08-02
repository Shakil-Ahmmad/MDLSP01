using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mass_Data_Education.Models;
using System.Web.Security;

namespace Mass_Data_Education.Repository
{
    public class RepClasses
    {
        Shared<Class> rep = new Shared<Class>();
        MassDataEducationEntities db = new MassDataEducationEntities();
        public IEnumerable<Class> GetAll()
        {
            var instuteID = Convert.ToInt32(Membership.GetUser().PasswordQuestion);
            var data = db.Class.Where(x => x.Deleted == false).Where(x => x.InstituteID == instuteID).ToList();
            return data;
        }
        public Class GetById(int id)
        {
            var data = rep.GetById(id);
            if (data.Deleted)
                return null;
            return data;
        }
        public Class Add(Class entity)
        {
            return rep.Add(entity);
        }
        public void Update(Class entity)
        {
            rep.Update(entity, x => x.Name);
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