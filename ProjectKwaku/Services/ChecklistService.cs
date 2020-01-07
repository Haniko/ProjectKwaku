using Models.Entities;
using Repositories;
using System.Collections.Generic;

namespace Services
{
    public class ChecklistService : IChecklistService
    {
        private readonly IChecklistRepository checklistRepository;

        public ChecklistService(IChecklistRepository checklistRepository)
        {
            this.checklistRepository = checklistRepository;
        }

        public IList<Checklist> GetAll(int checklistTypeId)
        {
            return checklistRepository.GetAll(checklistTypeId);
        }
    }
}
