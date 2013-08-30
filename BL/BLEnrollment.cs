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
        public static List<Enrollment> GetEnrollmentList(string student_id, ref List<string> errors)
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

            DALStudent.EnrollSchedule(student_id, schedule_id, ref errors);
        }

        public static void UpdateEnrollment(Enrollment enroll, ref List<string> errors)
        {
        }

        public static void DeleteEnrollement(string student_id, int schedule_id, ref List<string> errors)
        {
            BLCheck.checkStudentID(student_id, ref errors);

            // anything else to validate?

            if (errors.Count > 0)
                return;

            DALStudent.DropEnrolledSchedule(student_id, schedule_id, ref errors);
        }
    }
}
