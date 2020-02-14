using Models.Dtos;
using Repositories;
using System.Collections.Generic;

namespace Services
{
    public class CheckSheetService : ICheckSheetService
    {
        private readonly ICheckSheetRepository checkSheetRepo;

        public CheckSheetService(ICheckSheetRepository checkSheetRepo)
        {
            this.checkSheetRepo = checkSheetRepo;
        }

        public CheckSheetDto GetCheckSheet(int checkSheetTypeId)
        {
            return checkSheetRepo.GetCheckSheet(checkSheetTypeId);
        }

        public IEnumerable<CheckSheetSummaryDto> GetDashboard()
        {
            return checkSheetRepo.GetDashboard();
        }
    }
}
