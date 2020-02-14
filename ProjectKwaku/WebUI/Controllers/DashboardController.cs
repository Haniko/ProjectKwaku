using Microsoft.AspNetCore.Mvc;
using Models.Dtos;
using Services;
using System.Collections.Generic;

namespace WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        private readonly ICheckSheetService checkSheetService;

        public DashboardController(ICheckSheetService checkSheetService)
        {
            this.checkSheetService = checkSheetService;
        }

        [HttpGet]
        public IEnumerable<CheckSheetSummaryDto> Get()
        {
            return checkSheetService.GetDashboard();
        }
    }
}