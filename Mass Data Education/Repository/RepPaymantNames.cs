using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Mass_Data_Education.Models;
namespace Mass_Data_Education.Repository
{
    public class RepPaymantNames
    {


        Shared<PaymantNames> rep = new Shared<PaymantNames>();

        MassDataEducationEntities db = new MassDataEducationEntities();
        public IEnumerable<PaymantNames> GetAll()
        {
            //var users = hc.Users.Select(x => new { x.address, x.name, x.contact_number, x.email, x.password }).ToList();
            return rep.GetAll(c => c.Deleted == false);
        }
        public PaymantNames GetById(int id)
        {
            var data = rep.GetById(id);
            if (data.Deleted)
                return null;
            return data;
        }
        public PaymantNames Add(PaymantNames entity)
        {
            return rep.Add(entity);
        }
        public void Update(PaymantNames entity)
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