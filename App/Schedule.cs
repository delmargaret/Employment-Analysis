using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App
{
    class Schedule
    {
        public int ScheduleId { get; set; }
        public int ScheduleName { get; set; } //??
        public static List<Schedule> ScheduleList = new List<Schedule>();

        Schedule(int id, int name)
        {
            this.ScheduleId = id;
            this.ScheduleName = name;
        }

        public static Schedule CreateSchedule(int id, int name)
        {
            Schedule schedule = new Schedule(id, name);
            ScheduleList.Add(schedule);
            return schedule;
        }

        public static Schedule GetScheduleById(int id)
        {
            return ScheduleList.Find(item => item.ScheduleId == id);
        }
    }
}
