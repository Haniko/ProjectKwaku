using Models.Entities;
using Repositories;
using System.Collections.Generic;

namespace Services
{
    public class CheckSheetTypeService : ICheckSheetTypeService
    {
        private readonly ICheckSheetTypeRepository checkSheetTypeRepository;

        public CheckSheetTypeService(ICheckSheetTypeRepository checkSheetTypeRepository)
        {
            this.checkSheetTypeRepository = checkSheetTypeRepository;
        }

        public IList<CheckSheetType> GetAll()
        {
            return checkSheetTypeRepository.GetAll();
        }
    }
}
