using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization; // this is required

namespace POCO
{
  [DataContract]
  public class Major
  {
    [DataMember]
    public int id { get; set; }

    [DataMember]
    public string majorName { get; set; }

    public override string ToString()
    {
        return id + ";" +
               majorName + ";";
    }
  }
}
