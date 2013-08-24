using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization; // this is required

namespace POCO
{
  [DataContract]
  public class Course
  {
    [DataMember]
    public string id { get; set; }

    [DataMember]
    public string title { get; set; }

    [DataMember]
    public CourseLevel level { get; set; }//JUSTIN ADDED THIS

    [DataMember]
    public string description { get; set; }

    [DataMember]
    public int units { get; set; }

    [DataMember]//JUSTIN ADDED THIS
    public List<Prerequisite> prerequisite_list;//JUSTIN ADDED THIS

    public override string ToString()
    {
        return id + ";" +
               title + ";" +
               level + ";" +
               description + ";" +
               units + ";";
    }
  }
}
