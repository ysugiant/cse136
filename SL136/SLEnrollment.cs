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
  public class SLEnrollment : ISLEnrollment
  {
    public void InsertEnrollment(string student_id, int schedule_id, ref List<string> errors)
    {
      BLEnrollment.InsertEnrollment(student_id, schedule_id, ref errors);
    }

    public void DeleteEnrollment(string student_id, int schedule_id, ref List<string> errors)
    {
      BLEnrollment.DeleteEnrollment(student_id, schedule_id, ref errors);
    }

    public List<Enrollment> GetEnrollmentList( ref List<string> errors)
    {
      return BLEnrollment.GetEnrollment(ref errors);
    }

    public void UpdateEnrollment(string student_id, int schedule_id, string grade, ref List<string> errors)
    {
        BLEnrollment.UpdateEnrollment(student_id, schedule_id, grade, ref errors);
    }
  }
}
