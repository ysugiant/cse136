using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using POCO;
using DAL;

namespace BL
{
    public static class BLMajor
    {
        public static void InsertMajor(Major major, ref List<string> errors, out int ID)
        {
            ID = -1;
            BLCheck.checkMajorErrors(major, ref errors);
            if (errors.Count > 0)
                return;
            DALMajor.InsertMajor(major, ref errors, out ID);   
        }

        public static void UpdateMajor(Major major, ref List<string> errors)
        {
            BLCheck.checkMajorErrors(major, ref errors);
            if (errors.Count > 0)
                return;

            DALMajor.UpdateMajor(major, ref errors);
        }

        public static Major GetMajorDetail(int id, ref List<string> errors)
        {
            BLCheck.checkMajorID(id, ref errors);
            if (errors.Count > 0)
                return null;
            
            return (DALMajor.GetMajorDetail(id, ref errors));
        }

        public static void DeleteMajor(int id, ref List<string> errors)
        {
            BLCheck.checkMajorID(id, ref errors);
            if (errors.Count > 0)
                return;
            
            DALMajor.DeleteMajor(id, ref errors);
        }

        public static List<Major> GetMajorList(ref List<string> errors)
        {
            return DALMajor.GetMajorList(ref errors);
        }

    }
}
