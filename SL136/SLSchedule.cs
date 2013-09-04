using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using POCO;
using BL;

namespace SL136
{
  // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "SLSchedule" in both code and config file together.
  public class SLSchedule : ISLCourseSchedule
  {
    public List<ScheduledCourse> GetScheduleList(int year, string quarter, ref List<string> errors)
    {
      return BLCourseSchedule.GetCourseScheduleList(year, quarter, ref errors);
    }

    public ScheduledCourse GetCourseScheduleDetail(int id, ref List<string> errors)
    {
        return BLCourseSchedule.GetCourseScheduleDetail(id,ref errors);
    }

    public void InsertCourseSchedule(ScheduledCourse sched, ref List<string> errors, out int ID)
    {
        BLCourseSchedule.InsertCourseSchedule(sched, ref errors,out  ID);
    }

    public void UpdateCourseSchedule(ScheduledCourse sched, ref List<string> errors)
    {
        BLCourseSchedule.UpdateCourseSchedule(sched, ref errors);
    }

    public void DeleteCourseSchedule(int id, ref List<string> errors)
    {
        BLCourseSchedule.DeleteCourseSchedule(id, ref errors);
    }


  }
}
