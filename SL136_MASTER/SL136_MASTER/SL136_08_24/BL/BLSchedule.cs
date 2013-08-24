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
    public static List<ScheduleCourse> GetScheduleList(string year, string quarter, ref List<string> errors)
    {
      return (DALCourseSchedule.GetScheduleList(year, quarter, ref errors));
    }
  }
}
