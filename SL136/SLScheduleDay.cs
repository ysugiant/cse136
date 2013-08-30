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
  public class SLScheduleDay : ISLScheduleDay
  {
    public void InsertScheduleDay(string day, ref List<string> errors)
    {
      BLScheduleDay.InsertScheduleDay(day, ref errors);
    }

    public void DeleteScheduleDay(string id, ref List<string> errors)
    {
      BLScheduleDay.DeleteScheduleDay(id, ref errors);
    }

    public List<string> GetScheduleDayList(ref List<string> errors)
    {
      return BLScheduleDay.GetScheduleDayList(ref errors);
    }
  }
}
