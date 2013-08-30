using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using POCO;
using DAL;

namespace BL
{
    public static class BLEnrollment
    {
        public static List<Enrollment> GetEnrollment(string student_id, ref List<string> errors)
        {
            BLCheck.checkStudentID(student_id, ref errors);

            if (errors.Count > 0)
                return new List<Enrollment>();

            return (DALEnrollment.GetEnrollment(student_id, ref errors));
        }

        public static void InsertEnrollment(string student_id, int schedule_id, ref List<string> errors)
        {
            BLCheck.checkStudentID(student_id, ref errors);
            BLCheck.checkScheduleID(schedule_id, ref errors);

            if (errors.Count > 0)
                return;

            DALEnrollment.InsertEnrollment(student_id, schedule_id, ref errors);
        }

        public static void UpdateEnrollment(string student_id, int schedule_id, string grade, ref List<string> errors)
        {
            BLCheck.checkStudentID(student_id, ref errors);
            BLCheck.checkScheduleID(schedule_id, ref errors);
            BLCheck.checkGrade(grade, ref errors);

            if (errors.Count > 0)
                return;

            DALEnrollment.UpdateEnrollment(student_id, schedule_id, grade, ref errors);
        }

        public static void DeleteEnrollment(string student_id, int schedule_id, ref List<string> errors)
        {
            BLCheck.checkStudentID(student_id, ref errors);
            BLCheck.checkScheduleID(schedule_id, ref errors);

            if (errors.Count > 0)
                return;

            DALEnrollment.DeleteEnrollment(student_id, schedule_id, ref errors);
        }
    }
}
