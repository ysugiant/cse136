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
  // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "SLStudent" in both code and config file together.
  public class SLScheduleTime : ISLScheduleTime
  {
    public void InsertScheduleTime(string time, ref List<string> errors)
    {
      BLScheduleTime.InsertScheduleTime(time, ref errors);
    }

    public void DeleteScheduleTime(string id, ref List<string> errors)
    {
      BLScheduleTime.DeleteScheduleTime(id, ref errors);
    }

    public List<string> GetScheduleTimeList(ref List<string> errors)
    {
      return BLScheduleTime.GetScheduleTimeList(ref errors);
    }
  }
}
