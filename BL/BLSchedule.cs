using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using POCO;
using DAL;

namespace BL
{
  public static class BLSchedule
  {
    public static List<ScheduledCourse> GetScheduleList(int year, string quarter, ref List<string> errors)
    {
      return (DALCourseSchedule.GetCourseScheduleList(year, quarter, ref errors));
    }
  }
}
