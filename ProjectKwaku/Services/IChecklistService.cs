﻿using Models.Entities;
using System.Collections.Generic;

namespace Services
{
    public interface IChecklistService
    {
        IList<Checklist> GetAll(int checklistTypeId);
    }
}
