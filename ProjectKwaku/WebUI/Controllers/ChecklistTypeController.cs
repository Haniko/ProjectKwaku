﻿using Microsoft.AspNetCore.Mvc;
using Models.Entities;
using Services;
using System.Collections.Generic;

namespace WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChecklistTypeController : ControllerBase
    {
        private readonly IChecklistTypeService checklistTypeService;

        public ChecklistTypeController(IChecklistTypeService checklistTypeService)
        {
            this.checklistTypeService = checklistTypeService;
        }

        [HttpGet("all")]
        public IList<ChecklistType> GetAll()
        {
            return checklistTypeService.GetAll();
        }
    }
}