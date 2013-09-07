using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using POCO;
using DAL;

namespace BL
{
    public static class BLDepartment
    {
        public static Department GetDepartmentDetail(int id, ref List<string> errors)
        {
            BLCheck.checkDeptID(id, ref errors);
            if (errors.Count > 0)
                return null;

            return (DALDepartment.GetDepartmentDetail(id, ref errors));
        }

        public static List<Department> GetDepartmentList(ref List<string> errors)
        {
            return (DALDepartment.GetDepartmentList(ref errors));
        }

        public static void InsertDepartment(Department dept, ref List<string> errors)
        {
            BLCheck.checkDepartmentErrors(dept, ref errors);
            if (errors.Count > 0)
                return;

            DALDepartment.InsertDepartment(dept, ref errors);
        }

        public static void UpdateDepartment(Department dept, ref List<string> errors)
        {
            BLCheck.checkDepartmentErrors(dept, ref errors);
            if (errors.Count > 0)
                return;

            DALDepartment.UpdateDepartment(dept, ref errors);
        }

        public static void DeleteDepartment(int id, ref List<string> errors)
        {
            BLCheck.checkDeptID(id, ref errors);


            if (errors.Count > 0)
                return;

            DALDepartment.DeleteDepartment(id, ref errors);
        }
    }
}
