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


  }
}
