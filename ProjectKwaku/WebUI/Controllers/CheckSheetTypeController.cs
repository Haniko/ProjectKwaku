using Microsoft.AspNetCore.Mvc;
using Models.Entities;
using Services;
using System.Collections.Generic;

namespace WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheckSheetTypeController : ControllerBase
    {
        private readonly ICheckSheetTypeService checkSheetTypeService;

        public CheckSheetTypeController(ICheckSheetTypeService checkSheetTypeService)
        {
            this.checkSheetTypeService = checkSheetTypeService;
        }

        [HttpGet("all")]
        public IList<CheckSheetType> GetAll()
        {
            return checkSheetTypeService.GetAll();
        }
    }
}