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
  // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ISLSchedule" in both code and config file together.
  [ServiceContract]
  public interface ISLCourseSchedule
  {
    [OperationContract]
    List<ScheduledCourse> GetScheduleList(int year, string quarter, ref List<string> errors);

    [OperationContract]
    List<ScheduledCourse> GetScheduleListComplete(ref List<string> errors);

    [OperationContract]
    void InsertCourseSchedule(ScheduledCourse sched, ref List<string> errors, out int ID); //maybe need to fix,~!

    [OperationContract]
    void UpdateCourseSchedule(ScheduledCourse sched, ref List<string> errors);

    [OperationContract]
    void DeleteCourseSchedule(int id, ref List<string> errors);

    [OperationContract]
    ScheduledCourse GetCourseScheduleDetail(int id, ref List<string> errors);



  }
}
