using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization; // this is required

namespace POCO
{
    [DataContract]
    public class Grade
    {
        [DataMember]
        public int year { get; set; }

        [DataMember]
        public string quarter { get; set; }

        [DataMember]
        public Course course { get; set; }

        [DataMember]
        public string grade { get; set; }
    }
}
