using Models.Dtos;
using Models.Entities;
using System.Collections.Generic;

namespace Repositories
{
    public interface ICheckSheetRepository : IGenericRepository<CheckSheet>
    {
        CheckSheetDto GetCheckSheet(int checkSheetTypeId);

        IEnumerable<CheckSheetSummaryDto> GetSummary();
    }
}
