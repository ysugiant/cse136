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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "SLStudent" in both code and config file together.
    public class SLStaff : ISLStaff
    {
        public Staff GetStaff(int id, ref List<string> errors)
        {
            return BLStaff.GetStaff(id, ref errors);
        }

        public void InsertStaff(Staff staffMember, ref List<string> errors)
        {
            int newStaffID;
            BLStaff.InsertStaff(staffMember, ref errors, out newStaffID);
        }

        public void UpdateStaff(Staff staffMember, ref List<string> errors)
        {
            BLStaff.UpdateStaff(staffMember, ref errors);
        }

        public void DeleteStaff(int id, ref List<string> errors)
        {
            BLStaff.DeleteStaff(id, ref errors);
        }

        public List<Staff> GetStaffList(ref List<string> errors)
        {
            return BLStaff.GetStaffList(ref errors);
        }
    }
}
