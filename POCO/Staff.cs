﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization; // this is required

namespace POCO
{
 
  public class Staff
  {

    [DataMember]
    public int id { get; set; }

    [DataMember]
    public string first_name { get; set; }

    [DataMember]
    public string last_name { get; set; }

    [DataMember]
    public string email { get; set; }

    [DataMember]
    public string password { get; set; }

    [DataMember]
    public Department dept { get; set; }

    [DataMember]
    public bool isInstructor { get; set; }

    public override string ToString()
    {
        return id + "; " +
                first_name + "; " +
                last_name + "; " +
                email + "; " +
                password + "; " +
                dept.id + "; " +
                isInstructor + "; ";
    }
  }
}
