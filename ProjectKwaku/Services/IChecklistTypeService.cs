using Models.Entities;
using System.Collections.Generic;

namespace Services
{
    public interface IChecklistTypeService
    {
        IList<ChecklistType> GetAll();
    }
}