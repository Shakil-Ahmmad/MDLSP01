using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mass_Data_Education.Models;
using Mass_Data_Education.Repository;
namespace Mass_Data_Education.Repository
{
    public class RepTeacherClassSubject
    {

        Shared<TeacherClassSubject> rep = new Shared<TeacherClassSubject>();
        MassDataEducationEntities db = new MassDataEducationEntities();
        public IEnumerable<TeacherClassSubject> GetAll()
        {
            //var users = hc.Users.Select(x => new { x.address, x.name, x.contact_number, x.email, x.password }).ToList();
            return rep.GetAll(c => c.Deleted == false);
        }
        public TeacherClassSubject GetById(int id)
        {
            var data = rep.GetById(id);
            if (data.Deleted)
                return null;
            return data;
        }
        public TeacherClassSubject Add(TeacherClassSubject entity)
        {
            return rep.Add(entity);
        }
        public void Update(TeacherClassSubject entity)
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