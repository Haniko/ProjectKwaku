using Models.Entities;
using System.Collections.Generic;

namespace Repositories
{
    public interface ICheckSheetTypeRepository : IGenericRepository<CheckSheetType>
    {
        IList<CheckSheetType> GetAll();
    }
}
