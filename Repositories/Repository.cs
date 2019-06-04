using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Interfaces;
using WPF_Project;

namespace Repositories
{
    class Repository<TEntity> : IRepository<TEntity> where TEntity : class
    {
        public async Task<TEntity> Delete(TEntity o)
        {
            db.Set<TEntity>().Remove(o);
            await db.SaveChangesAsync();
            return o;
        }

        public async Task<IEnumerable<TEntity>> Get(int count, int skip) => await db.Set<TEntity>().Skip(skip).Take(count).ToListAsync();

        public async Task<IEnumerable<TEntity>> Get() => await db.Set<TEntity>().ToListAsync();

        public async Task<TEntity> Get(int id) => await db.Set<TEntity>().FindAsync(id);

        public async Task<TEntity> Insert(TEntity o)
        {
            db.Set<TEntity>().Add(o);
            await db.SaveChangesAsync();
            return o;
        }

        public async Task<TEntity> Update(TEntity o, int id)
        {
            TEntity entity = await db.Set<TEntity>().FindAsync(id);
            if (entity != null)
            {
                db.Entry(entity).CurrentValues.SetValues(o);
                await db.SaveChangesAsync();
            }
            return o;
        }

        public Repository(CollectionsDatabaseEntities db) => this.db = db;

        private readonly CollectionsDatabaseEntities db;
    }
}
