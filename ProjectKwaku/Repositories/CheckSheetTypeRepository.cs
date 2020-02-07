using Microsoft.EntityFrameworkCore;
using Models.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Repositories
{
    public class CheckSheetTypeRepository : ICheckSheetTypeRepository
    {
        private readonly IDbContext dbContext;

        public CheckSheetTypeRepository(IDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IList<CheckSheetType> GetAll()
        {
            return dbContext.CheckSheetTypes.AsNoTracking().ToList();
        }
    }
}
