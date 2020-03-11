using Microsoft.AspNetCore.Mvc;
using Models.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;

namespace WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TimeZoneController : ControllerBase
    {
        [HttpGet]
        public IEnumerable<TimeZoneDto> GetAllTimeZones()
        {
            var timeZones = TimeZoneInfo.GetSystemTimeZones();

            return timeZones.Select(x => new TimeZoneDto
            {
                Id = x.Id,
                DisplayName = x.DisplayName
            });
        }
    }
}