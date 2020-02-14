using Models.Dtos;
using System.Collections.Generic;

namespace Services
{
    public interface ICheckSheetService
    {
        CheckSheetDto GetCheckSheet(int checkSheetTypeId);

        IEnumerable<CheckSheetSummaryDto> GetDashboard();
    }
}
