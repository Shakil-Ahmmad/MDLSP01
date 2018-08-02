using System;
using System.Linq;
using System.Reflection;
using System.Data.Entity;
using System.Linq.Expressions;
using Mass_Data_Education.Models;
using System.Collections.Generic;

namespace Mass_Data_Education.Repository
{
    public class Shared<T> : IDisposable where T : class
    {
        MassDataEducationEntities db = ContextHelper.GetContext(); // new Habib_ChemicalsEntities();
        DbSet<T> ds;
        public Shared()
        {
            ds = db.Set<T>();
        }

        //public IEnumerable<T> GetAll(params Expression<Func<T, bool>>[] filter)
        //{
        //    IQueryable<T> query = ds;
        //    foreach (var item in filter)
        //    {
        //        query.Where(item);
        //    }

        //    return query.ToList();
        //}

        public IEnumerable<T> GetAll(Expression<Func<T, bool>> filter = null)
        {
            return ds.Where(filter).ToList();
        }


        public T GetById(int id)
        {
            return ds.Find(id);
        }

        public T GetById(string id)
        {
            return ds.Find(id);
        }

        public T Add(T entity, int created_by = 0)
        {
            ds.Add(entity);
            //TrySetProperty(entity, "created_by", created_by);
            //TrySetProperty(entity, "update_date", DateTime.UtcNow);
            db.SaveChanges();
            return entity;
        }

        //public void Update(T entity, int updated_by = 0)
        //{
        //    //TrySetProperty(entity, "updated_by", created_by);
        //    //TrySetProperty(entity, "update_date", DateTime.UtcNow);
        //    db.Entry<T>(entity).State = EntityState.Modified;
        //    db.SaveChanges();
        //}

        public virtual void Update(T entity, params Expression<Func<T, object>>[] updatedProperties)
        {
            //dbEntityEntry.State = EntityState.Modified; --- I cannot do this.
            ds.Attach(entity);
            //Ensure only modified fields are updated.
            var dbEntityEntry = db.Entry(entity);
            if (updatedProperties.Any())
            {
                //update explicitly mentioned properties
                foreach (var property in updatedProperties)
                {
                    dbEntityEntry.Property(property).IsModified = true;
                }
            }
            else
            {
                //no items mentioned, so find out the updated entries
                foreach (var property in dbEntityEntry.OriginalValues.PropertyNames)
                {
                    var original = dbEntityEntry.OriginalValues.GetValue<object>(property);
                    var current = dbEntityEntry.CurrentValues.GetValue<object>(property);
                    if (original != null && !original.Equals(current))
                        dbEntityEntry.Property(property).IsModified = true;
                }
            }
            db.SaveChanges();
        }
        

        public void Delete(int id)
        {
            T entity = ds.Find(id);
            TrySetProperty(entity, "Deleted", true);
            db.Entry<T>(entity).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Delete(string id)
        {
            T entity = ds.Find(id);
            TrySetProperty(entity, "Deleted", true);
            db.Entry<T>(entity).State = EntityState.Modified;
            db.SaveChanges();
        }

        public void Dispose()
        {
            db.Dispose();
        }

        private void TrySetProperty(object obj, string property, object value)
        {
            var prop = obj.GetType().GetProperty(property, BindingFlags.Public | BindingFlags.Instance);
            if (prop != null && prop.CanWrite)
                prop.SetValue(obj, value, null);
        }
    }
}