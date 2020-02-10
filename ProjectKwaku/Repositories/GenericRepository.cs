using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;

namespace Repositories
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        protected readonly CheckSheetContext dbContext;

        public GenericRepository(CheckSheetContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public void Add(TEntity entity)
        {
            dbContext.Set<TEntity>().Add(entity);
        }

        public void AddMany(TEntity[] entity)
        {
            dbContext.Set<TEntity>().AddRange(entity);
        }

        public IList<TEntity> GetAll()
        {
            return dbContext.Set<TEntity>().AsNoTracking().ToList();
        }

        public void SaveChanges()
        {
            dbContext.SaveChanges();
        }
    }
}
