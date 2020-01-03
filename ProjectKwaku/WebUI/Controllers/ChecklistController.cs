using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Services;

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

        // GET: api/Checklist
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/Checklist/5
        [HttpGet("{id}", Name = "Get")]
        public string Get(int id)
        {
            return "value";
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
