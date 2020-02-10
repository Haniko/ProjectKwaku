using CsvHelper.Configuration;
using Models.Entities;

namespace DataImporter.Models
{
    class CheckSheetRowMap : ClassMap<CheckSheetRow>
    {
        public CheckSheetRowMap()
        {
            Map(x => x.Mon).ConvertUsing(row => string.IsNullOrEmpty(row.GetField("Mon")) ? 0 : (int)DaysOfWeek.Mon);
            Map(x => x.Tue).ConvertUsing(row => string.IsNullOrEmpty(row.GetField("Tue")) ? 0 : (int)DaysOfWeek.Tue);
            Map(x => x.Wed).ConvertUsing(row => string.IsNullOrEmpty(row.GetField("Wed")) ? 0 : (int)DaysOfWeek.Wed);
            Map(x => x.Thu).ConvertUsing(row => string.IsNullOrEmpty(row.GetField("Thu")) ? 0 : (int)DaysOfWeek.Thu);
            Map(x => x.Fri).ConvertUsing(row => string.IsNullOrEmpty(row.GetField("Fri")) ? 0 : (int)DaysOfWeek.Fri);
            Map(x => x.Sat).ConvertUsing(row => string.IsNullOrEmpty(row.GetField("Sat")) ? 0 : (int)DaysOfWeek.Sat);
            Map(x => x.Sun).ConvertUsing(row => string.IsNullOrEmpty(row.GetField("Sun")) ? 0 : (int)DaysOfWeek.Sun);
            Map(x => x.Comments).Name("Comments");
            Map(x => x.Description).Name("Brief Description");
            Map(x => x.Notes).Name("Notes");
            Map(x => x.Title).Name("Title");
            Map(x => x.Url).Name("Documentation full Link");
        }
    }
}
