using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using Core.Persistence.Dynamic;

namespace Core.Persistence.Repository
{
    public interface IRepository<TEntity>
    {
        TEntity Add(TEntity entity);
        void Delete(TEntity entity);
        TEntity Update(TEntity entity);
        TEntity GetById(int id);
        IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate);
        IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate, DynamicQuery dynamic);
    }
}
