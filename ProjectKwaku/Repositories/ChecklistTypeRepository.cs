using Microsoft.EntityFrameworkCore;
using Models.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Repositories
{
    public class ChecklistTypeRepository : IChecklistTypeRepository
    {
        private readonly IDbContext dbContext;

        public ChecklistTypeRepository(IDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IList<ChecklistType> GetAll()
        {
            return dbContext.ChecklistTypes.AsNoTracking().ToList();
        }
    }
}
