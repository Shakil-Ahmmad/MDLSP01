using Mass_Data_Education.Models;
using System.Collections.Generic;

namespace Mass_Data_Education.Repository
{
    public class RepGender
    {
        Shared<Gender> rep = new Shared<Gender>();
        MassDataEducationEntities db = new MassDataEducationEntities();
        public IEnumerable<Gender> GetAll()
        {
            //var users = hc.Users.Select(x => new { x.address, x.name, x.contact_number, x.email, x.password }).ToList();
            return rep.GetAll(c => c.Deleted == false);
        }
        public Gender GetById(int id)
        {
            var data = rep.GetById(id);
            if (data.Deleted)
                return null;
            return data;
        }
        public Gender Add(Gender entity)
        {
            return rep.Add(entity);
        }
        public void Update(Gender entity)
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