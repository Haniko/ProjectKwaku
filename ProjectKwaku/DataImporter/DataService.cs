using CsvHelper;
using DataImporter.Models;
using Models.Entities;
using Repositories;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace DataImporter
{
    class DataService
    {
        private readonly IGenericRepository<CheckSheet> checkSheetRepo;
        private readonly IGenericRepository<CheckSheetType> checkSheetTypeRepo;
        private readonly IGenericRepository<Task> taskRepo;
        private readonly IGenericRepository<TaskStatus> taskStatusRepo;

        public DataService(
            IGenericRepository<CheckSheet> checkSheetRepo,
            IGenericRepository<CheckSheetType> checkSheetTypeRepo,
            IGenericRepository<Task> taskRepo,
            IGenericRepository<TaskStatus> taskStatusRepo)
        {
            this.checkSheetRepo = checkSheetRepo;
            this.checkSheetTypeRepo = checkSheetTypeRepo;
            this.taskRepo = taskRepo;
            this.taskStatusRepo = taskStatusRepo;
        }

        public int AddCheckSheetType(string name, string timeZoneId)
        {
            var checkSheetType = new CheckSheetType
            {
                Name = name,
                TimeZoneId = timeZoneId
            };

            checkSheetTypeRepo.Add(checkSheetType);
            checkSheetTypeRepo.SaveChanges();

            return checkSheetType.CheckSheetTypeId;
        }

        public Task[] ImportTasks(string filePath, int checkSheetTypeId)
        {
            using var streamReader = new StreamReader(filePath, Encoding.GetEncoding(1250));
            using var csv = new CsvReader(streamReader, CultureInfo.InvariantCulture)
            {
                Configuration =
                {
                    Encoding = Encoding.GetEncoding(1250),
                    ShouldSkipRecord = (record) => record.All(field => string.IsNullOrEmpty(field)),
                    TrimOptions = CsvHelper.Configuration.TrimOptions.Trim
                }
            };

            csv.Configuration.RegisterClassMap<CheckSheetRowMap>();

            var csvRecords = csv.GetRecords<CheckSheetRow>().ToList();
            var tasks = MapCsvToTasks(csvRecords, checkSheetTypeId);

            taskRepo.AddMany(tasks);
            taskRepo.SaveChanges();

            return tasks;
        }

        public int AddCheckSheet(int checkSheetTypeId)
        {
            var checkSheet = new CheckSheet
            {
                CheckSheetTypeId = checkSheetTypeId,
                SignOffUserId = null,
                StartDateUtc = DateTime.Today,
                Comment = "",
            };

            checkSheetRepo.Add(checkSheet);
            checkSheetRepo.SaveChanges();

            return checkSheet.CheckSheetId;
        }

        public void AddTaskStatuses(Task[] tasks, int checkSheetId)
        {
            List<TaskStatus> statuses = new List<TaskStatus>();

            foreach(Task task in tasks)
            {
                var status = new TaskStatus
                {
                    CheckSheetId = checkSheetId,
                    TaskId = task.TaskId,
                    AssignedUserId = null,
                    Comment = "",
                    State = State.None
                };

                statuses.Add(status);
            }

            taskStatusRepo.AddMany(statuses.ToArray());
            taskStatusRepo.SaveChanges();
        }

        private Task[] MapCsvToTasks(List<CheckSheetRow> records, int checkSheetTypeId)
        {
            return records
                .Select(record => new Task
                {
                    CheckSheetTypeId = checkSheetTypeId,
                    ActiveDays = record.getActiveDays(),
                    Description = record.Description,
                    Notes = record.Notes,
                    StartTimeUtc = new TimeSpan(),
                    Title = record.Title,
                    Url = record.Url,
                    ValidFromDateUtc = DateTime.UtcNow,
                    ValidUntilDateUtc = null
                })
                .ToArray();
        }
    }
}
