using Models.Entities;
using System.Collections.Generic;

namespace Repositories
{
    public interface IChecklistRepository
    {
        IList<Checklist> GetAll(int checklistTypeId);
    }
}
