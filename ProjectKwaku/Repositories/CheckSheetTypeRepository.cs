using Models.Entities;

namespace Repositories
{
    public class CheckSheetTypeRepository : GenericRepository<CheckSheetType>, ICheckSheetTypeRepository
    {
        public CheckSheetTypeRepository(CheckSheetContext dbContext)
            : base(dbContext)
        {
        }
    }
}
