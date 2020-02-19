using Microsoft.EntityFrameworkCore;
using Models.Dto;
using Models.Dtos;
using Models.Entities;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Repositories
{
    public class CheckSheetRepository : GenericRepository<CheckSheet>, ICheckSheetRepository
    {
        public CheckSheetRepository(CheckSheetContext dbContext)
            : base(dbContext)
        {
        }

        public CheckSheetDto GetCheckSheet(int checkSheetTypeId)
        {
            return dbContext.CheckSheets
                .AsNoTracking()
                .Include(x => x.CheckSheetType)
                .Include(x => x.SignOffUser)
                .Include(x => x.TaskStatuses)
                .Include(x => x.TaskStatuses)
                    .ThenInclude(y => y.Task)
                .Select(x => new CheckSheetDto
                {
                    CheckSheetTypeId = x.CheckSheetTypeId,
                    CheckSheetName = x.CheckSheetType.Name,
                    StartDateUtc = x.StartDateUtc,
                    DisplayDate = x.StartDateUtc.Date.ToShortDateString(),
                    Tasks = x.TaskStatuses.Select(taskStatus => new TaskDto
                    {
                        TaskId = taskStatus.TaskId,
                        AssignedUserName = taskStatus.AssignedUser.Name,
                        DisplayTime = "",
                        Status = taskStatus.State.ToString("G"),
                        TaskComment = taskStatus.Comment,
                        TaskDescription = taskStatus.Task.Description,
                        TaskNotes = taskStatus.Task.Notes,
                        TaskTitle = taskStatus.Task.Title,
                        Url = taskStatus.Task.Url
                    })
                })
                .FirstOrDefault(x => x.CheckSheetTypeId == checkSheetTypeId && x.StartDateUtc == DateTime.Today);
        }

        public IEnumerable<CheckSheetSummaryDto> GetDashboard()
        {
            return dbContext.CheckSheets
                .AsNoTracking()
                .Include(x => x.TaskStatuses)
                .Where(x => x.StartDateUtc == DateTime.Today)
                .Select(x => new CheckSheetSummaryDto
                {
                    CheckSheetName = x.CheckSheetType.Name,
                    CheckSheetTypeId = x.CheckSheetTypeId,
                    CompletedCount = x.TaskStatuses.Count(y => y.State == State.Completed),
                    InProgressCount = x.TaskStatuses.Count(y => y.State == State.InProgress),
                    NotStartedCount = x.TaskStatuses.Count(y => y.State == State.None)
                });
        }
    }
}
