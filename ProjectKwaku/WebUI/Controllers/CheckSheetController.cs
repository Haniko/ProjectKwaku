using Microsoft.AspNetCore.Mvc;
using Models.Entities;
using Services;
using System.Collections.Generic;

namespace WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheckSheetController : ControllerBase
    {
        private readonly ICheckSheetService checkSheetService; 

        public CheckSheetController(ICheckSheetService checkSheetService)
        {
            this.checkSheetService = checkSheetService;
        }

        // GET: api/checksheet/{checkSheetTypeId}
        [HttpGet("{checkSheetTypeId}")]
        public IList<CheckSheet> GetAll(int checkSheetTypeId)
        {
            return checkSheetService.GetAll(checkSheetTypeId);
        }
    }
}
