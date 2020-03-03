using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;

namespace Repositories
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        void Add(TEntity entity);

        void AddMany(TEntity[] entity);

        IQueryable<TEntity> FindBy(Expression<Func<TEntity, bool>> predicate);

        IList<TEntity> GetAll();

        void SaveChanges();
    }
}