using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Models.Entities;
using Services;

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

        // GET: api/checklisttypes
        [HttpGet]
        public IList<ChecklistType> GetAll()
        {
            return checklistTypeService.GetAll();
        }
    }
}