using Microsoft.EntityFrameworkCore;
using Models.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Repositories
{
    public class CheckSheetRepository : GenericRepository<CheckSheet>, ICheckSheetRepository
    {
        public CheckSheetRepository(CheckSheetContext dbContext)
            : base(dbContext)
        {
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
