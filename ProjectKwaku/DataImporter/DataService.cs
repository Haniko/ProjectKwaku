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
        private readonly ICheckSheetTypeRepository checkSheetTypeRepo;
        private readonly IGenericRepository<Task> taskRepo;

        public DataService(
            ICheckSheetTypeRepository checkSheetTypeRepo,
            IGenericRepository<Task> taskRepo)
        {
            this.checkSheetTypeRepo = checkSheetTypeRepo;
            this.taskRepo = taskRepo;
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

        public int ImportTasks(string filePath, int checkSheetTypeId)
        {
            using var streamReader = new StreamReader(filePath);
            using var csv = new CsvReader(streamReader, CultureInfo.InvariantCulture)
            {
                Configuration =
                {
                    Encoding = Encoding.UTF8,
                    ShouldSkipRecord = (record) => record.All(field => string.IsNullOrEmpty(field)),
                    TrimOptions = CsvHelper.Configuration.TrimOptions.Trim
                }
            };

            csv.Configuration.RegisterClassMap<CheckSheetRowMap>();

            var csvRecords = csv.GetRecords<CheckSheetRow>().ToList();
            var tasks = MapCsvToTasks(csvRecords, checkSheetTypeId);

            taskRepo.AddMany(tasks);
            taskRepo.SaveChanges();

            return tasks.Length;
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
