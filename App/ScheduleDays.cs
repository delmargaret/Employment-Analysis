using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App
{
    class ScheduleDays
    {
        public int ScheduleDayId { get; set; }
        public Schedule schedule { get; set; }
        public Days days { get; set; }
        public static List<ScheduleDays> ScheduleDaysList { get; set; }

        public ScheduleDays() { }

        public ScheduleDays CreateScheduleDay(int id, int scheduleid, int dayid)
        {
            ScheduleDays scheduleday = new ScheduleDays(id, Schedule.GetScheduleById(scheduleid), Days.GetDayById(dayid));
            ScheduleDaysList.Add(scheduleday);
            return scheduleday;
        }

        public ScheduleDays(int id, Schedule schedule, Days days)
        {
            this.ScheduleDayId = id;
            this.schedule = schedule;
            this.days = days;
        }

        public static ScheduleDays GetScheduleDayById(int id)
        {
            return ScheduleDaysList.Find(item => item.ScheduleDayId == id);
        }

        public static List<ScheduleDays> GetAllScheduleDaysById(int scheduleid)
        {
            return ScheduleDaysList.FindAll(item => item.schedule.ScheduleId == scheduleid);
        }

        public void ChangeDayInSchedule(int id, int newdayid)
        {
            ScheduleDaysList.Find(item => item.ScheduleDayId == id).days = Days.GetDayById(newdayid);
        }

        public void RemoveDayFromSchedule(int id)
        {
            ScheduleDaysList.RemoveAll(item => item.ScheduleDayId == id);
        }

        public void RemoveAllDaysFromSchedule()
        {
            ScheduleDaysList.RemoveRange(0, ScheduleDaysList.Count());
        }
    }
}
