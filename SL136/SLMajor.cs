using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using POCO;
using BL;

namespace SL136
{
    public class SLMajor : ISLMajor
    {
        public List<Tuple<string, string>> GetMajorList(ref List<string> errors)
        {
            return BLMajor.GetMajorList(ref errors);
        }

        public void InsertMajor(Major major, ref List<string> errors, out int ID)
        {
             BLMajor.InsertMajor(major , ref errors, out ID);
        }

        public void UpdateMajor(Major major, ref List<string> errors)
        {
            BLMajor.UpdateMajor(major, ref errors);
        }

        public void DeleteMajor(int id, ref List<string> errors)
        {
            BLMajor.DeleteMajor(id, ref errors);
        }

        public Major GetMajorDetail(int id, ref List<string> errors)
        {
           return BLMajor.GetMajorDetail(id, ref errors);
        }
    }
}
