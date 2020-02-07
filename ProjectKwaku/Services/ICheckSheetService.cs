using Models.Entities;
using System.Collections.Generic;

namespace Services
{
    public interface ICheckSheetService
    {
        IList<CheckSheet> GetAll(int checkSheetTypeId);
    }
}
