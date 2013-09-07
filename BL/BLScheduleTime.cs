using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using POCO;
using DAL;

namespace BL
{
    public static class BLScheduleTime
    {
        public static void InsertScheduleTime(string time, ref List<string> errors)
        {
            BLCheck.checkScheduleTime(time, ref errors);

            if (errors.Count > 0)
                return;

            DALScheduleTime.InsertScheduleTime(time, ref errors);
        }

        public static Dictionary<string, string> GetScheduleTimeList(ref List<string> errors)
        {
            return (DALScheduleTime.GetScheduleTimeList(ref errors));
        }

        public static void DeleteScheduleTime(int id, ref List<string> errors)
        {
            BLCheck.checkScheduleTimeID(id, ref errors);

            if (errors.Count > 0)
                return;

            DALScheduleTime.DeleteScheduleTime(id, ref errors);
        }

    }
}
