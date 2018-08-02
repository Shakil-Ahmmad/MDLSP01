using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mass_Data_Education.Models;

namespace Mass_Data_Education.Repository
{
    public class RepExamNames
    {

        Shared<ExamNames> rep = new Shared<ExamNames>();

        MassDataEducationEntities db = new MassDataEducationEntities();
        public IEnumerable<ExamNames> GetAll()
        {
            //var users = hc.Users.Select(x => new { x.address, x.name, x.contact_number, x.email, x.password }).ToList();
            return rep.GetAll(c => c.Deleted == false);
        }
        public ExamNames GetById(int id)
        {
            var data = rep.GetById(id);
            if (data.Deleted)
                return null;
            return data;
        }
        public ExamNames Add(ExamNames entity)
        {
            return rep.Add(entity);
        }
        public void Update(ExamNames entity)
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