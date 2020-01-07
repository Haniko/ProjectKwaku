using Microsoft.EntityFrameworkCore;
using Models.Entities;
using System.Collections.Generic;
using System.Linq;

namespace Repositories
{
    public class ChecklistRepository : IChecklistRepository
    {
        private readonly IDbContext dbContext;

        public ChecklistRepository(IDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IList<Checklist> GetAll(int checklistTypeId)
        {
            return dbContext.Checklists
                .AsNoTracking()
                .Include(x => x.ChecklistType)
                .Include(x => x.SignOffUser)
                .Where(x => x.ChecklistTypeId == checklistTypeId)
                .ToList();
        }
    }
}
