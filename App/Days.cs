using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App
{
    class Days
    {
        public int DayId { get; protected set; }
        public string DayName { get; protected set; }
        public static List<Days> DaysList = new List<Days>();

        public Days() { }

        Days(int id, string day)
        {
            DayId = id;
            DayName = day;
        }

        public static List<Days> CreateDays()
        {
            Days monday = new Days(1, "Monday");
            Days tuesday = new Days(2, "Tuesday");
            Days wednesday = new Days(3, "Wednesday");
            Days thursday = new Days(1, "Thursday");
            Days friday = new Days(2, "Friday");
            Days saturday = new Days(3, "Saturday");
            DaysList.Add(monday);
            DaysList.Add(tuesday);
            DaysList.Add(wednesday);
            DaysList.Add(thursday);
            DaysList.Add(friday);
            DaysList.Add(saturday);
            return DaysList;
        }

        public static Days GetDayById(int id)
        {
            return DaysList.Find(item => item.DayId == id);
        }
    }
}
