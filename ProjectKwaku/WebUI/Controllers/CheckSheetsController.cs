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
        private readonly ICheckSheetRepository checkSheetRepo;
        private readonly ICheckSheetService checkSheetService;
        private readonly IGenericRepository<CheckSheetType> checkSheetTypeRepo;

        public CheckSheetsController(
            ICheckSheetRepository checkSheetRepo,
            ICheckSheetService checkSheetService,
            IGenericRepository<CheckSheetType> checkSheetTypeRepo)
        {
            this.checkSheetRepo = checkSheetRepo;
            this.checkSheetService = checkSheetService;
            this.checkSheetTypeRepo = checkSheetTypeRepo;
        }

        [HttpGet("summary")]
        public IEnumerable<CheckSheetSummaryDto> GetSummary()
        {
            return checkSheetRepo.GetSummary();
        }

        [HttpGet("types")]
        public IList<CheckSheetType> GetTypes()
        {
            return checkSheetTypeRepo.GetAll();
        }

        [HttpPost("types")]
        public CheckSheetType AddType(CheckSheetType checkSheetType)
        {
            return checkSheetType;
        }

        [HttpGet("edit/{checkSheetTypeId}")]
        public CheckSheetEditDto GetCheckSheetEditDto(int checkSheetTypeId)
        {
            return checkSheetService.GetCheckSheetEditDto(checkSheetTypeId);
        }

        [HttpGet]
        public IList<CheckSheet> GetAll()
        {
            return checkSheetRepo.GetAll();
        }

        [HttpGet("{checkSheetTypeId}")]
        public CheckSheetDto GetCheckSheet(int checkSheetTypeId)
        {
            return checkSheetRepo.GetCheckSheet(checkSheetTypeId);
        }
    }
}
