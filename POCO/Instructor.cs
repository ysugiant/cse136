﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization; // this is required

namespace POCO
{
    [DataContract]
    public class Instructor : Staff
    {
        [DataMember]
        public List<ScheduleCourse> courseSchedule;
    }
}
