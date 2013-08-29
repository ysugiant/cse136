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
        public static List<string> GetScheduleDayList(ref List<string> errors)
        {
            return (DALScheduleDay.GetScheduleDayList(ref errors));
        }

        public static void DeleteScheduleDay(string day, ref List<string> errors)
        {
            if (day == null)
            {
                errors.Add("Invalid day");
            }

            if (errors.Count > 0)
                return;

            DALScheduleDay.DeleteScheduleDay(day, ref errors);
        }

        public static void InsertEnrollment(string student_id, int schedule_id, ref List<string> errors)
        {
            if (student_id == null)//using regex
            {
                errors.Add("Invalid student ID");
            }

            if (schedule_id < 0)
            {
                errors.Add("Cannot have a negative schedule ID.");
            }
            if (errors.Count > 0)
                return;

            DALStudent.EnrollSchedule(student_id, schedule_id, ref errors);
        }

        public static void DeleteEnrollement(string student_id, int schedule_id, ref List<string> errors)
        {
            if (student_id == null)//using regex
            {
                errors.Add("Invalid student ID");
            }

            // anything else to validate?

            if (errors.Count > 0)
                return;

            DALStudent.DropEnrolledSchedule(student_id, schedule_id, ref errors);
        }
    }
}
