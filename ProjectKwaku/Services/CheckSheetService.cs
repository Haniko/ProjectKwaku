using Models.Dtos;
using Models.Entities;
using Repositories;
using System.Collections.Generic;
using System.Linq;

namespace Services
{
    public class CheckSheetService : ICheckSheetService
    {
        private readonly ICheckSheetRepository checkSheetRepo;
        private readonly IGenericRepository<CheckSheetType> checkSheetTypeRepo;
        private readonly IGenericRepository<Task> taskRepo;

        public CheckSheetService(
            ICheckSheetRepository checkSheetRepo,
            IGenericRepository<CheckSheetType> checkSheetTypeRepo,
            IGenericRepository<Task> taskRepo)
        {
            this.checkSheetRepo = checkSheetRepo;
            this.checkSheetTypeRepo = checkSheetTypeRepo;
            this.taskRepo = taskRepo;
        }

        public CheckSheetDto GetCheckSheet(int checkSheetTypeId)
        {
            return checkSheetRepo.GetCheckSheet(checkSheetTypeId);
        }

        public CheckSheetEditDto GetCheckSheetEditDto(int checkSheetTypeId)
        {
            return new CheckSheetEditDto
            {
                CheckSheetType = checkSheetTypeRepo
                    .FindBy(x => x.CheckSheetTypeId == checkSheetTypeId)
                    .FirstOrDefault(),
                ActiveTasks = taskRepo
                    .FindBy(x => x.CheckSheetTypeId == checkSheetTypeId && x.ValidUntilDateUtc == null)
                    .ToList()
            };
        }

        public IEnumerable<CheckSheetSummaryDto> GetDashboard()
        {
            return checkSheetRepo.GetSummary();
        }
    }
}
