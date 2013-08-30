using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using POCO;
using DAL;

namespace BL
{
    public static class BLScheduleDay
    {
        public static void InsertScheduleDay(string day, ref List<string> errors)
        {
            BLCheck.checkScheduleDay(day, ref errors);

            if (errors.Count > 0)
                return;

            DALScheduleDay.InsertScheduleDay(day, ref errors);
        }

        public static List<string> GetScheduleDayList(ref List<string> errors)
        {
            return (DALScheduleDay.GetScheduleDayList(ref errors));
        }

        public static void DeleteScheduleDay(string day, ref List<string> errors)
        {
            BLCheck.checkScheduleDay(day, ref errors);

            if (errors.Count > 0)
                return;

            DALScheduleDay.DeleteScheduleDay(day, ref errors);
        }

    }
}
