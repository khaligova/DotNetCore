using Core.Domain;
using Core.Persistence.Dynamic;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;

namespace Core.Persistence.Repository
{
    public class BaseRepository<TContext, TEntity> : IRepository<TEntity>
       where TEntity : BaseEntity
       where TContext : DbContext
    {
        private readonly TContext _context;
        public BaseRepository(TContext context)
        {
            _context = context;
        }
        public TEntity Add(TEntity entity)
        {
            TEntity addedEntity=_context.Add(entity).Entity;
            _context.SaveChanges();
            return addedEntity;
        }

        public void Delete(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Deleted;
            _context.SaveChanges();
        }

        public IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate)
        {
             return _context.Set<TEntity>().Where(predicate);
        }

        public IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate, DynamicQuery dynamic)
        {
            return _context.Set<TEntity>().Where(predicate);
        }

        public TEntity GetById(int id)
        {
            return _context.Set<TEntity>().Where(e => e.Id == id).FirstOrDefault();
        }

        public TEntity Update(TEntity entity)
        {
            TEntity updatedEntity = _context.Update(entity).Entity;
            _context.SaveChanges();
            return updatedEntity;

        }
    }
}
