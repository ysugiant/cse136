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
  // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ISLCourse" in both code and config file together.
  [ServiceContract]
  public interface ISLCourse
  {
      [OperationContract]
      List<Course> GetCourseList(ref List<string> errors);

      [OperationContract]
      void InsertCourse(Course course, ref List<string> errors);

      [OperationContract]
      void UpdateCourse(Course course, ref List<string> errors);

      [OperationContract]
      void DeleteCourse(string coursetitle, ref List<string> errors);

      [OperationContract]
      Course GetCourse(string coursetitle, ref List<string> errors);

      [OperationContract]
      void InsertPrerequisite(int courseid, int pre_course_id, ref List<string> errors);

      [OperationContract]
      void DeletePrerequisite(int courseid, int pre_course_id, ref List<string> errors);

      [OperationContract]
      void UpdatePrerequisite(int courseid, int pre_course_id, int change_id, ref List<string> errors);
  }
}
