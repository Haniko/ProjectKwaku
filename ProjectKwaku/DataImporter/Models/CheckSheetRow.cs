namespace DataImporter.Models
{
    class CheckSheetRow
    {
        public int Mon { get; set; }

        public int Tue { get; set; }

        public int Wed { get; set; }

        public int Thu { get; set; }

        public int Fri { get; set; }

        public int Sat { get; set; }

        public int Sun { get; set; }

        public string Comments { get; set; }

        public string Description { get; set; }

        public string Notes { get; set; }

        public string Title { get; set; }

        public string Url { get; set; }

        public int getActiveDays()
        {
            return Mon + Tue + Wed + Thu + Fri + Sat + Sun;
        }
    }
}
