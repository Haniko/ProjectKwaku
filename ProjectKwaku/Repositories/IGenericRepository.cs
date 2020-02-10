using System.Collections.Generic;

namespace Repositories
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        void Add(TEntity entity);

        void AddMany(TEntity[] entity);

        IList<TEntity> GetAll();

        void SaveChanges();
    }
}