using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization; // this is required

namespace POCO
{
    [DataContract]
    public class Prerequisite {
        [DataMember]
        public Course course { get; set; }

        [DataMember]
        public List<Course> prereqList { get; set; }

        public override string ToString()
        {
            return "" + course.ToString();
        }

    }
}
