using DataAccessLayer.Abstract;
using DataAccessLayer.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Repositories
{
    public class GenericRepository<T> : IGenericDal<T> where T : class
    {
        KampContext db = new KampContext();
        DbSet<T> _object;

        public GenericRepository()
        {
            _object = db.Set<T>();
        }
        public void Delete(T entity)
        {
            var deletedEntity = db.Entry(entity);
            deletedEntity.State = EntityState.Deleted;
            db.SaveChanges();
        }

        public List<T> GetAll()
        {
            var result = _object.ToList();
            return result;
        }

        public T GetById(int id)
        {
            var result = _object.Find(id);
            return result;
        }

        public void Insert(T entity)
        {
            db.Entry(entity).State = EntityState.Added;
            db.SaveChanges();
        }

        public void Update(T entity)
        {
            db.Entry(entity).State = EntityState.Modified;
            db.SaveChanges();
        }
    }
}
