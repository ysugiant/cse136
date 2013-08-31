using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using BL;
using POCO;

namespace SL136
{
  // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "SLCourse" in both code and config file together.
  public class SLCourse : ISLCourse
  {
      //should take the list error to test it
      public List<Course> GetCourseList(ref List<string> errors)
      {
          return BLCourse.GetCourseList(ref errors);
      }

      public Course GetCourse(string coursetitle, ref List<string> errors)
      {
          return BLCourse.GetCourse(coursetitle, ref errors);
      }

      public void InsertCourse(Course course, ref List<string> errors)
      {
          BLCourse.InsertCourse(course, ref errors);
      }

      public void UpdateCourse(Course course, ref List<string> errors)
      {
          BLCourse.UpdateCourse(course, ref errors);
      }

      public void DeleteCourse(string coursetitle, ref List<string> errors)
      {
          BLCourse.DeleteCourse(coursetitle, ref errors);
      }


      public void InsertPrerequisite(int courseid, int pre_course_id, ref List<string> errors)
      {
          BLCourse.InsertPrerequisite(courseid, pre_course_id, ref errors);
      }



      public void DeletePrerequisite(int courseid, int pre_course_id, ref List<string> errors)
      {
          BLCourse.DeletePrerequisite(courseid, pre_course_id, ref errors);
      }


      public void UpdatePrerequisite(int courseid, int pre_course_id, int change_id, ref List<string> errors)
      {
          BLCourse.UpdatePrerequisite(courseid, pre_course_id, change_id, ref errors);
      }
  }
}
