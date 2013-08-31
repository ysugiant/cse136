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
        public static void InsertMajor(string majorName, int deptID, ref List<string> errors, out int ID)
        {
            BLCheck.checkMajorName(majorName, ref errors);
            BLCheck.checkDeptID(deptID, ref errors);
            DALMajor.InsertMajor(majorName, deptID, ref errors, out ID);   
        }

        public static void UpdateMajor(int majorID, string majorName, int deptID, ref List<string> errors)
        {
            BLCheck.checkMajorID(majorID, ref errors);
            BLCheck.checkMajorName(majorName, ref errors);
            BLCheck.checkDeptID(deptID, ref errors);
            if (errors.Count > 0)
                return;

            DALMajor.UpdateMajor(majorID, majorName, deptID, ref errors);
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

        public static List<Tuple<string, string>> GetMajorList(ref List<string> errors)
        {
            return DALMajor.GetMajorList(ref errors);
        }

    }
}
