using System;

namespace Models.Entities
{
    [Flags]
    public enum DaysOfWeek : int
    {
        Mon = 1,
        Tue = 2,
        Wed = 4,
        Thu = 8,
        Fri = 16,
        Sat = 32,
        Sun = 64,
        Everyday = 128
    }
}
