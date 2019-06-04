using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;
using Entities;

namespace Repositories
{
    public class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        public TEntity Delete(TEntity o)
        {
            db.Set<TEntity>().Remove(o);
            db.SaveChanges();
            return o;
        }

        public IEnumerable<TEntity> Get(int count, int skip) => db.Set<TEntity>().Skip(skip).Take(count).ToList();

        public IEnumerable<TEntity> Get() => db.Set<TEntity>().ToList();

        public TEntity Get(int id) => db.Set<TEntity>().Find(id);

        public TEntity Insert(TEntity o)
        {
            db.Set<TEntity>().Add(o);
            db.SaveChanges();
            return o;
        }

        public TEntity Update(TEntity o, int id)
        {
            TEntity entity = db.Set<TEntity>().Find(id);
            if (entity != null)
            {
                db.Entry(entity).CurrentValues.SetValues(o);
                db.SaveChanges();
            }
            return o;
        }

        public Repository(CollectionsDatabaseEntities db) => this.db = db;

        private readonly CollectionsDatabaseEntities db;
    }
}
