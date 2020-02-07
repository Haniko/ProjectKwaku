using Models.Entities;
using System.Collections.Generic;

namespace Repositories
{
    public interface ICheckSheetRepository
    {
        IList<CheckSheet> GetAll(int checkSheetTypeId);
    }
}
