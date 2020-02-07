using CsvHelper;
using DataImporter.Models;
using Models.Entities;
using System;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;

namespace DataImporter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");

            using var reader = new StreamReader("../../../files/Copy of NA Daily Checksheet.csv");

            using var csv = new CsvReader(reader, CultureInfo.InvariantCulture);
            csv.Configuration.Encoding = Encoding.UTF8;
            csv.Configuration.ShouldSkipRecord = (record) => record.All(field => string.IsNullOrEmpty(field));
            csv.Configuration.TrimOptions = CsvHelper.Configuration.TrimOptions.Trim;

            var csvRecords = csv.GetRecords<CheckSheetRow>().ToList();

            var tasks = csvRecords.Select(record => new Task
            {
                Description = record.Description,
                Notes = record.Notes,
                StartTimeUtc = new TimeSpan(),
                Title = record.Title,
                Url = record.DocumentationUrl,
                ValidFromDateUtc = DateTime.UtcNow,
                ValidUntilDateUtc = null
            });
        }
    }
}
