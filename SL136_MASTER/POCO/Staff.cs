using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization; // this is required

namespace POCO
{
 
  public interface Staff
  {

    [DataMember]
    int id { get; set; }

    [DataMember]
    string first_name { get; set; }

    [DataMember]
    string last_name { get; set; }

    [DataMember]
    string email { get; set; }

    [DataMember]
    string password { get; set; }

    [DataMember]
    Department dept { get; set; }

  }
}
