using CsvHelper.Configuration.Attributes;

namespace DataImporter.Models
{
    class CheckSheetRow
    {
        public string Mon { get; set; }

        public string Tue { get; set; }

        public string Wed { get; set; }

        public string Thu { get; set; }

        public string Fri { get; set; }

        public string Sat { get; set; }

        public string Sun { get; set; }
      
        public string Title { get; set; }

        [Name("Brief Description")]
        public string Description { get; set; }

        [Name("Documentation full Link")]
        public string DocumentationUrl { get; set; }

        public string Notes { get; set; }

        public string Comments { get; set; }
    }
}
