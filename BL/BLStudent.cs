using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using POCO;
using DAL;

namespace BL
{
  public static class BLStudent
  {
    public static void InsertStudent(Student student, ref List<string> errors)
    {
        BLCheck.checkStudentErrors(student, ref errors);
      if (errors.Count > 0)
        return;

      DALStudent.InsertStudent(student, ref errors);
    }

    public static void UpdateStudent(Student student, ref List<string> errors)
    {
        BLCheck.checkStudentID(student.id, ref errors);

      if (errors.Count > 0)
        return;

      DALStudent.UpdateStudent(student, ref errors);
    }

    public static Student GetStudent(string id, ref List<string> errors)
    {
      BLCheck.checkStudentID(id, ref errors);

      if (errors.Count > 0)
        return null;

      return (DALStudent.GetStudentDetail(id, ref errors));
    }

    public static void DeleteStudent(string id, ref List<string> errors)
    {
      BLCheck.checkStudentID(id, ref errors);

      if (errors.Count > 0)
        return;

      DALStudent.DeleteStudent(id, ref errors);
    }

    public static List<Student> GetStudentList(ref List<string> errors)
    {
      return DALStudent.GetStudentList(ref errors);
    }

    /*public static void EnrollSchedule(string student_id, int schedule_id, ref List<string> errors)
    {
      ScheduledCourse sCourse = BLCourseSchedule.GetCourseScheduleDetail(student_id, ref errors);
      
      BLCheck.checkScheduleErrors(
      if (errors.Count > 0)
        return;

      DALStudent.EnrollSchedule(student_id, schedule_id, ref errors);
    }

    public static void DropEnrolledSchedule(string student_id, int schedule_id, ref List<string> errors)
    {
      if (student_id == null)
      {
        errors.Add("Invalid student ID");
      }

      // anything else to validate?

      if (errors.Count > 0)
        return;

      DALStudent.DropEnrolledSchedule(student_id, schedule_id, ref errors);
    }*/

  }
}
