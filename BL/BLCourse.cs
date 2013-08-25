using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POCO;
using DAL;

namespace BL
{
  public class BLCourse
  {
    //should pass by the default list ref errors 
    public static List<Course> GetCourseList(ref List<string> errors)
    {
      return (DALCourse.GetCourseList(ref errors));
    }

  }
}
