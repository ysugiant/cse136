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
        public static Department GetDepartmentDetail(string name, ref List<string> errors)
        {
            BLCheck.checkDeptName(name, ref errors);
            if (errors.Count > 0)
                return null;

            return (DALDepartment.GetDepartmentDetail(name, ref errors));
        }

        public static void InsertDepartment(Department dept, ref List<string> errors)
        {
            /*BLCheck.checkStudentID(student_id, ref errors);
            BLCheck.checkScheduleID(schedule_id, ref errors);
            */
            if (errors.Count > 0)
                return;

            DALDepartment.InsertDepartment(dept, ref errors);
        }

        public static void UpdateDepartment(Department dept, ref List<string> errors)
        {
        }

        public static void DeleteDepartment(string name, ref List<string> errors)
        {
            BLCheck.checkDeptName(name, ref errors);


            if (errors.Count > 0)
                return;

            DALDepartment.DeleteDepartment(name, ref errors);
        }
    }
}
