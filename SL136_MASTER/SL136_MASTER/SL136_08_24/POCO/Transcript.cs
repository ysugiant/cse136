using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization; // this is required

namespace POCO
{
    [DataContract]
    public class Transcript
    {
        [DataMember]
        public Student student { get; set; }

        [DataMember]
        public List<Grade> grade { get; set; }
    }
}
