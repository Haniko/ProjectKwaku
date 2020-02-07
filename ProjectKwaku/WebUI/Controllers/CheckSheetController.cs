using Microsoft.AspNetCore.Mvc;
using Models.Dto;
using Models.Entities;
using Services;
using System;
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
        public IList<TaskDto> Get(int checkSheetTypeId)
        {
            User assignedUser = new User
            {
                UserId = 1,
                Name = "Liam"
            };

            CheckSheetType checkSheetType = new CheckSheetType
            {
                CheckSheetTypeId = checkSheetTypeId,
                Name = "EMEA"
            };

            CheckSheet checkSheet = new CheckSheet
            {
                CheckSheetId = 1,
                CheckSheetTypeId = checkSheetTypeId,
                SignOffUserId = null,
                StartDateUtc = DateTime.UtcNow,
                Comment = "comment",
                CheckSheetType = checkSheetType,
                TaskStatuses = new List<TaskStatus>
                {
                    new TaskStatus
                    {
                        TaskStatusId = 1,
                        CheckSheetId = 1,
                        TaskId = 1,
                        AssignedUserId = null,
                        Comment = "task status comment",
                        State = State.None,
                        Task = new Task
                        {
                            TaskId = 1,
                            CheckSheetTypeId = checkSheetTypeId,
                            Title = "Production Canada (CSCPRC) Backups Start",
                            Description = "CSCPRC backups will kick off. Emails will be received to monitor backups but ensure that you are logged into CSCPRC and keeping an eye on OPCOMS and job failures. See Documentation",
                            Url = "www.google.com",
                            ActiveDays = (int) DaysOfWeek.Mon,
                            StartTimeUtc = new TimeSpan(9, 0, 0),
                            ValidFromDateUtc = DateTime.UtcNow,
                            ValidUntilDateUtc = null,
                            ChecklistType = checkSheetType,
                            Notes = "notes #1"
                        },
                        AssignedUser = assignedUser
                    },
                    new TaskStatus
                    {
                        TaskStatusId = 2,
                        CheckSheetId = 1,
                        TaskId = 2,
                        AssignedUserId = null,
                        Comment = "task status comment 2",
                        State = State.InProgress,
                        Task = new Task
                        {
                            TaskId = 2,
                            CheckSheetTypeId = checkSheetTypeId,
                            Title = "Test Canada (CSCPRC) Backups Start",
                            Description = "CSCPRC backups will kick off. Emails will be received to monitor backups but ensure that you are logged into CSCPRC and keeping an eye on OPCOMS and job failures. See Documentation",
                            Url = "www.google.com",
                            ActiveDays = (int) DaysOfWeek.Mon,
                            StartTimeUtc = new TimeSpan(9, 0, 0),
                            ValidFromDateUtc = DateTime.UtcNow,
                            ValidUntilDateUtc = null,
                            ChecklistType = checkSheetType,
                            Notes = "notes #2"
                        },
                        AssignedUser = assignedUser
                    }
                }
            };

            List<TaskDto> tasks = new List<TaskDto>();

            foreach(TaskStatus taskStatus in checkSheet.TaskStatuses)
            {
                tasks.Add(new TaskDto
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
                });
            }

            return tasks;

            //return checkSheetService.GetAll(checkSheetTypeId);
        }
    }
}
