using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using POCO;
using DAL;

namespace BL
{
    public static class BLCourseSchedule
    {
        public static void InsertCourseSchedule(ScheduledCourse sched, ref List<string> errors)
        {
            BLCheck.checkCourseScheduleErrors(sched, ref errors);

            int newScheduleID;
            DALCourseSchedule.InsertCourseSchedule(sched, ref errors, out newScheduleID);
        }

        public static void UpdateCourseSchedule(ScheduledCourse sched, ref List<string> errors)
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

            DALStaff.UpdateStaff(staffMember, ref errors);*/
        }

        public static void DeleteCourseSchedule(int id, ref List<string> errors)
        {/*
            if (id < 0)
            {
                errors.Add("Invalid staff ID. ID must be a non-negative integer.");
            }

            if (errors.Count > 0)
                return;

            DALStaff.DeleteStaff(id, ref errors);*/
        }

        public static ScheduledCourse GetCourseScheduleDetail(int id, ref List<string> errors)
        {/*
            if (id < 0)
            {
                errors.Add("Invalid staff ID. ID must be a non-negative integer.");
            }

            // anything else to validate?

            if (errors.Count > 0)
                return null;*/

            return (DALCourseSchedule.GetCourseScheduleDetail(id, ref errors));
        }

        public static List<ScheduledCourse> GetCourseScheduleList(int year, string quarter, ref List<string> errors)
        {
            return (DALCourseSchedule.GetCourseScheduleList(year, quarter, ref errors));
        }
    }
}
