using Models.Entities;
using System.Collections.Generic;

namespace Repositories
{
    public interface ICheckSheetTypeRepository
    {
        IList<CheckSheetType> GetAll();
    }
}
