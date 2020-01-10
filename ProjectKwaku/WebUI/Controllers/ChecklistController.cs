using Microsoft.AspNetCore.Mvc;
using Models.Entities;
using Services;
using System.Collections.Generic;

namespace WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChecklistController : ControllerBase
    {
        private readonly IChecklistService checklistService; 

        public ChecklistController(IChecklistService checklistService)
        {
            this.checklistService = checklistService;
        }

        // GET: api/checklist/{checklistTypeId}
        [HttpGet("{checklistTypeId}")]
        public IList<Checklist> GetAll(int checklistTypeId)
        {
            return checklistService.GetAll(checklistTypeId);
        }
    }
}
