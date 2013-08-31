using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using POCO;
using DAL;

namespace BL
{
    public static class BLCourseSchedule
    {
        public static void InsertCourseSchedule(ScheduledCourse sched, ref List<string> errors, out int ID)
        {
            BLCheck.checkCourseScheduleErrors(sched, ref errors);
            DALCourseSchedule.InsertCourseSchedule(sched, ref errors, out ID);
        }

        public static void UpdateCourseSchedule(ScheduledCourse sched, ref List<string> errors)
        {
            BLCheck.checkCourseScheduleErrors(sched, ref errors);
            if (errors.Count > 0)
                return;

            DALCourseSchedule.UpdateCourseSchedule(sched, ref errors);
        }

        public static void DeleteCourseSchedule(int id, ref List<string> errors)
        {
            BLCheck.checkScheduleID(id, ref errors);
            if (errors.Count > 0)
                return;

            DALCourseSchedule.DeleteCourseSchedule(id, ref errors);
        }

        public static ScheduledCourse GetCourseScheduleDetail(int id, ref List<string> errors)
        {
            BLCheck.checkScheduleID(id, ref errors);
            if (errors.Count > 0)
                return null;

            return (DALCourseSchedule.GetCourseScheduleDetail(id, ref errors));
        }

        public static List<ScheduledCourse> GetCourseScheduleList(int year, string quarter, ref List<string> errors)
        {
            BLCheck.checkYear(year, ref errors);
            BLCheck.checkQuarter(quarter, ref errors);
            if (errors.Count > 0)
                return null;

            return (DALCourseSchedule.GetCourseScheduleList(year, quarter, ref errors));
        }
    }
}
