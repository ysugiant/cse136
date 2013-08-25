﻿using System;
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
  }
}
