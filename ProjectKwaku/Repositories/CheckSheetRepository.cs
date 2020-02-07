using Microsoft.EntityFrameworkCore;
using Models.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Repositories
{
    public class CheckSheetRepository : ICheckSheetRepository
    {
        private readonly IDbContext dbContext;

        public CheckSheetRepository(IDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IList<CheckSheet> GetAll(int checkSheetTypeId)
        {
            return dbContext.CheckSheets
                .AsNoTracking()
                .Include(x => x.CheckSheetType)
                .Include(x => x.SignOffUser)
                .Include(x => x.TaskStatuses)
                .Include(x => x.TaskStatuses)
                    .ThenInclude(y => y.Task)
                .Where(x => x.CheckSheetTypeId == checkSheetTypeId)
                .ToList();
        }
    }
}
