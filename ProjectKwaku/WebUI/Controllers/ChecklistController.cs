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

        // POST: api/Checklist
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT: api/Checklist/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
