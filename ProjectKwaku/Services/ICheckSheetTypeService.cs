using Models.Entities;
using System.Collections.Generic;

namespace Services
{
    public interface ICheckSheetTypeService
    {
        IList<CheckSheetType> GetAll();
    }
}