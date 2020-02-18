using Microsoft.AspNetCore.Mvc;
using Models.Dtos;
using Models.Entities;
using Repositories;
using Services;
using System.Collections.Generic;

namespace WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CheckSheetsController : ControllerBase
    {
        private readonly ICheckSheetService checkSheetService;
        private readonly IGenericRepository<CheckSheetType> checkSheetTypeRepo;

        public CheckSheetsController(
            ICheckSheetService checkSheetService,
            IGenericRepository<CheckSheetType> checkSheetTypeRepo)
        {
            this.checkSheetService = checkSheetService;
            this.checkSheetTypeRepo = checkSheetTypeRepo;
        }

        [HttpPost("types")]
        public CheckSheetType AddType(CheckSheetType checkSheetType)
        {
            return checkSheetType;
        }

        [HttpGet("summary")]
        public IEnumerable<CheckSheetSummaryDto> GetSummary()
        {
            return checkSheetService.GetDashboard();
        }

        [HttpGet("types")]
        public IList<CheckSheetType> GetTypes()
        {
            return checkSheetTypeRepo.GetAll();
        }

        [HttpGet("{checkSheetTypeId}")]
        public CheckSheetDto GetCheckSheet(int checkSheetTypeId)
        {
            return checkSheetService.GetCheckSheet(checkSheetTypeId);
        }
    }
}
