using Blog.DatabaseContext;
using Blog.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Blog.Service
{
    public abstract class EntityService<T> : IEntityService<T> where T : BaseEntity
    {
        protected IDbContext _context;
        protected IDbSet<T> _dbset;

        public EntityService(IDbContext context)
        {
            _context = context;
            _dbset = _context.Set<T>();
        }

        public virtual void Create(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException("entity");
            }
            _dbset.Add(entity);
            _context.SaveChanges();
        }


        public void Delete(T entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");
            _dbset.Remove(entity);
            _context.SaveChanges(); 
        }

        public IEnumerable<T> SelectAll()
        {
            return _dbset.AsEnumerable<T>();
        }

        public void Update(T entity)
        {
            if (entity == null) throw new ArgumentNullException("entity");
            _context.Entry(entity).State = System.Data.Entity.EntityState.Modified;
            _context.SaveChanges();
        }
    }
}