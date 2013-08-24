using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization; // this is required

namespace POCO
{
  [DataContract]
  public class Student
  {
    [DataMember]
    public string id { get; set; }

    [DataMember]
    public string ssn { get; set; }

    [DataMember]
    public string first_name { get; set; }

    [DataMember]
    public string last_name { get; set; }

    [DataMember]
    public string email { get; set; }

    [DataMember]
    public string password { get; set; }

    [DataMember]
    public float shoe_size { get; set; }

    [DataMember]
    public int weight { get; set; }

    [DataMember]
    public StudentLevel level { get; set; }//JUSTIN ADDED THIS

    [DataMember]
    public int status { get; set; }

    [DataMember]
    //public Major major { get; set; }
    public int major { get; set; }//JUSTIN ADDED THIS
    
    [DataMember]
    public List<ScheduleCourse> enrolled;//JUSTIN ADDED THIS

    public override string ToString()
    {
        return id + ";" +
               ssn + ";" +
               first_name + ";" +
               last_name + ";" +
               email + ";" +
               password + ";" +
               shoe_size + ";" +
               weight + ";" +
               level + ";" +
               status + ";" +
               major + ";";
    }
  }
}
