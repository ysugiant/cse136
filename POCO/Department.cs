using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization; // this is required

namespace POCO
{
  [DataContract]
  public class Department
  {
    [DataMember]
    public int id { get; set; }

    [DataMember]
    public string deptName { get; set; }

    [DataMember]
    public int chairID { get; set; }

    public override string ToString()
    {
        return id + ";" +
               deptName + ";" +
               chairID + ";";
    }
  }
}
