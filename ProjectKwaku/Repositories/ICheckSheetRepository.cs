using Models.Entities;
using System.Collections.Generic;

namespace Repositories
{
    public interface ICheckSheetRepository : IGenericRepository<CheckSheet>
    {
        IList<CheckSheet> GetAll(int checkSheetTypeId);
    }
}
