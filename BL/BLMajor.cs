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
        public static void InsertMajor(string majorName, int deptID, ref List<string> errors)
        {/*
            BLCheck.checkStaffErrors(staffMember, ref errors);

            int newStaffID;
            DALStaff.InsertStaff(staffMember, ref errors, out newStaffID);*/
        }

        public static void UpdateMajor(int majorID, string majorName, int deptID, ref List<string> errors)
        {/*
            if (staffMember == null)
            {
                errors.Add("Staff member cannot be null");
            }

            if (staffMember.id < 5)
            {
                errors.Add("Invalid staff ID");
            }

            if (errors.Count > 0)
                return;

            DALStaff.UpdateStaff(staffMember, ref errors); */
        }

        public static Major GetMajorDetail(int id, ref List<string> errors)
        {/*
            if (id < 0)
            {
                errors.Add("Invalid staff ID. ID must be a non-negative integer.");
            }

            // anything else to validate?

            if (errors.Count > 0)
                return null;
            */
            return (DALMajor.GetMajorDetail(id, ref errors));
        }

        public static void DeleteMajor(int id, ref List<string> errors)
        {/*
            if (id < 0)
            {
                errors.Add("Invalid staff ID. ID must be a non-negative integer.");
            }

            if (errors.Count > 0s)
                return;

            DALStaff.DeleteStaff(id, ref errors);*/
        }

        public static List<Tuple<string, string>> GetMajorList(ref List<string> errors)
        {
            return DALMajor.GetMajorList(ref errors);
        }

    }
}
