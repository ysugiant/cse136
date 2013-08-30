using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using POCO;
using DAL;

namespace BL
{
    public static class BLStaff
    {
        public static void InsertStaff(Staff staffMember, List<string> errors)
        {
            BLCheck.checkStaffErrors(staffMember, ref errors);

            int newStaffID;
            DALStaff.InsertStaff(staffMember, ref errors, out newStaffID);
        }

        public static void UpdateStaff(Staff staffMember, ref List<string> errors)
        {
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

            DALStaff.UpdateStaff(staffMember, ref errors);
        }

        public static Staff GetStaff(int id, ref List<string> errors)
        {
            if (id < 0)
            {
                errors.Add("Invalid staff ID. ID must be a non-negative integer.");
            }

            // anything else to validate?

            if (errors.Count > 0)
                return null;

            return (DALStaff.GetStaffDetail(id, ref errors));
        }

        public static void DeleteStaff(int id, ref List<string> errors)
        {
            if (id < 0)
            {
                errors.Add("Invalid staff ID. ID must be a non-negative integer.");
            }

            if (errors.Count > 0)
                return;

            DALStaff.DeleteStaff(id, ref errors);
        }

        public static List<Staff> GetStaffList(ref List<string> errors)
        {
            return DALStaff.GetStaffList(ref errors);
        }

        /*public static void EnrollSchedule(int staff_id, int schedule_id, ref List<string> errors)
        {
            if (staff_id == null)
            {
                errors.Add("Invalid staff ID");
            }

            // anything else to validate?
            // JUSTIN : added the following test. I admit, kinda pointless. No one would try a negative schedule ID, but who knows.
            if (schedule_id < 0)
            {
                errors.Add("Cannot have a negative schedule ID.");
            }
            if (errors.Count > 0)
                return;

            //DALStaff.EnrollSchedule(staff_id, schedule_id, ref errors);
            DALEnrollment.InsertEnrollment(staff_id, );
        }*/

        /*public static void DropEnrolledSchedule(int staff_id, int schedule_id, ref List<string> errors)
        {
            if (staff_id == null)
            {
                errors.Add("Invalid staff ID");
            }

            // anything else to validate?

            if (errors.Count > 0)
                return;

            DALStaff.DropEnrolledSchedule(staff_id, schedule_id, ref errors);
        }*/

    }
}
