using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization; // this is required

namespace POCO
{
  [DataContract]
  public class ScheduleCourse
  {
    [DataMember]
    public int id { get; set; }

    [DataMember]
    public int year { get; set; }

    [DataMember]
    public string quarter { get; set; }

    [DataMember]
    public string session { get; set; }

    [DataMember]
    public Course course {get; set;}

    [DataMember]
    public string time { get; set; }

    [DataMember]
    public string day { get; set; }

    [DataMember]
    public string instructor_fName { get; set; }//JUSTIN ADDED THIS

    [DataMember]
    public string instructor_lName { get; set; }//JUSTIN ADDED THIS

    public override string ToString()
    {
        return id + ";" +
               year + ";" +
               quarter + ";" +
               session + ";" +
               course + ";" +
               time + ";" +
               day + ";" +
               instructor_fName + ";" +//JUSTIN ADDED THIS
               instructor_lName + ";";//JUSTIN ADDED THIS
    }
  }
}
