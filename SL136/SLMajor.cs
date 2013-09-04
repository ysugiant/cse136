using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using BL;
using POCO;

namespace SL136
{
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "SLCourse" in both code and config file together.
    public class SLMajor : ISLMajor
    {
        //should take the list error to test it
        public List<Major> GetMajorList(ref List<string> errors)
        {
            return BLMajor.GetMajorList(ref errors);
        }

        public void InsertMajor(Major major, ref List<string> errors)
        {
            int newMajorID;
            BLMajor.InsertMajor(major, ref errors, out newMajorID);
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
            return (BLMajor.GetMajorDetail(id, ref errors));
        }
    }
}
