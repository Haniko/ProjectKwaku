using Models.Entities;
using Repositories;
using System.Collections.Generic;

namespace Services
{
    public class CheckSheetService : ICheckSheetService
    {
        private readonly ICheckSheetRepository checkSheetRepository;

        public CheckSheetService(ICheckSheetRepository checkSheetRepository)
        {
            this.checkSheetRepository = checkSheetRepository;
        }

        public IList<CheckSheet> GetAll(int checkSheetTypeId)
        {
            return checkSheetRepository.GetAll(checkSheetTypeId);
        }
    }
}
