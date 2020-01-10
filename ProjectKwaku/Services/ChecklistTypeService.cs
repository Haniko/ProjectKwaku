using Models.Entities;
using Repositories;
using System.Collections.Generic;

namespace Services
{
    public class ChecklistTypeService : IChecklistTypeService
    {
        private readonly IChecklistTypeRepository checklistTypeRepository;

        public ChecklistTypeService(IChecklistTypeRepository checklistTypeRepository)
        {
            this.checklistTypeRepository = checklistTypeRepository;
        }

        public IList<ChecklistType> GetAll()
        {
            return checklistTypeRepository.GetAll();
        }
    }
}
