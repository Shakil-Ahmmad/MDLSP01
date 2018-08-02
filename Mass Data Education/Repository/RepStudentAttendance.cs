using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mass_Data_Education.Models;

namespace Mass_Data_Education.Repository
{
    public class RepStudentAttendance
    {

        

        Shared<StudentAttendance> rep = new Shared<StudentAttendance>();

        MassDataEducationEntities db = new MassDataEducationEntities();
        public IEnumerable<StudentAttendance> GetAll()
        {
            //var users = hc.Users.Select(x => new { x.address, x.name, x.contact_number, x.email, x.password }).ToList();
            return rep.GetAll(c => c.Deleted == false);
        }
        public StudentAttendance GetById(int id)
        {
            var data = rep.GetById(id);
            if (data.Deleted)
                return null;
            return data;
        }
        public StudentAttendance Add(StudentAttendance entity)
        {
            return rep.Add(entity);
        }
        public void Update(StudentAttendance entity)
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