using Models.Entities;
using System.Collections.Generic;

namespace Repositories
{
    public interface IChecklistTypeRepository
    {
        IList<ChecklistType> GetAll();
    }
}
