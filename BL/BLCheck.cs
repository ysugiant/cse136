using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace BL
{
    public class BLCheck
    {
        //MAIN METHODS
        /*
        public static void checkStudentErrors(string email, ref List<string> errors)
        {
        
        }
       
        public static void checkStaffErrors(string email, ref List<string> errors)
        {
        
        }
        
        public static void checkCourseErrors(string email, ref List<string> errors)
        {
        
        }
       
        public static void checkDepartmentErrors(string email, ref List<string> errors)
        {
        
        }
        
        public static void checkMajorErrors(string email, ref List<string> errors)
        {
        
        }
       
        public static void checkScheduleErrors(string email, ref List<string> errors)
        {
        
        }
        
        public static void checkEnrollmentErrors(string email, ref List<string> errors)
        {
        
        }
        */

        //GENERAL ERROR CHECKING
        public static void checkEmail(string email, ref List<string> errors)
        {
            if (email != null && email.Length <= 50)
            {
                string strRegex = @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z";
                if (!Regex.IsMatch(email, strRegex))
                    errors.Add("The student email format is incorrect");
            } 
        }

        public static void checkName(string name, string FirstOrLast, ref List<string> errors)
        {
            if (name == null)
                errors.Add(FirstOrLast + " name cannot be null");
            else if (name == "")
                errors.Add(FirstOrLast + " name cannot be empty");
            else if (name.Length > 50)
                errors.Add(FirstOrLast + " name cannot greater than 50 characters");
        }

        public static void checkFirstName(string name, ref List<string> errors)
        {
            checkName(name, "First", ref errors);
        }

        public static void checkLastName(string name, ref List<string> errors)
        {
            checkName(name, "Last", ref errors);
        }

        public static void checkPassword(string password, ref List<string> errors)
        {
            if (password == null)
                errors.Add("password cannot be null");
            else if (password == "")
                errors.Add("password cannot be empty");
            else if (password.Length > 15 || password.Length < 8)
                errors.Add("password length cannot exceed 15 characters or be less than 8 characters");
        }

        public static void checkID(int id, string tableName, ref List<string> errors)
        {
            if (id < 0)
                errors.Add(tableName + " ID cannot be negative");
        }

        public static void checkMajorID(int id, ref List<string> errors)
        {
            checkID(id, "Major", ref errors);
        }

        public static void checkStudentID(string st_id, ref List<string> errors)
        {
            if (st_id == null)
                errors.Add("Student ID cannot be null");
            else if (st_id == "")
                errors.Add("Student ID cannot be empty");
            else if (st_id.Length > 9)
                errors.Add("Student ID cannot be more than 9");
            else
            {
                string strRegex = @"^A[0-9]{8}";
                if (!Regex.IsMatch(st_id, strRegex))
                    errors.Add("The student ID format is incorrect");
            }
        }

        public static void checkScheduleID(int id, ref List<string> errors)
        {
            checkID(id, "Schedule", ref errors);
        }

        public static void checkDeptID(int id, ref List<string> errors)
        {
            checkID(id, "Department", ref errors);
        }

        public static void checkStaffID(int id, ref List<string> errors)
        {
            checkID(id, "Staff", ref errors);
        }

        public static void checkCourseID(int id, ref List<string> errors)
        {
            checkID(id, "Course", ref errors);
        }

        public static void checkScheduleDayID(int id, ref List<string> errors)
        {
            checkID(id, "Schedule Day", ref errors);
        }

        public static void checkScheduleTimeID(int id, ref List<string> errors)
        {
            checkID(id, "Schedule Time", ref errors);
        }

        //STUDENT
        public static void checkStudentLevel(string name, ref List<string> errors)
        {

        }

        public static void checkStudentStatus(string name, ref List<string> errors)
        {

        }

        public static void checkStudentShoeSize(string name, ref List<string> errors)
        {

        }

        public static void checkStudentWeight(string name, ref List<string> errors)
        {

        }

        public static void checkStudentSSN(string name, ref List<string> errors)
        {

        }
        //IN GENERAL
            //CheckName
            //CheckMajorID
            //CheckEmail
            //CheckPassword
            //CheckStudentID


        //ENROLLMENT
        public static void checkGrade(string name, ref List<string> errors)
        {

        }
        //IN GENERAL
            //CheckStudentID
            //CheckScheduleID


        //MAJOR
        public static void checkMajorName(string name, ref List<string> errors)
        {

        }
        //IN GENERAL
            //CheckMajorID
            //CheckDeptID

        //DEPARTMENT
        public static void checkChairID(string name, ref List<string> errors)
        {

        }

        public static void checkDeptName(string name, ref List<string> errors)
        {

        }
        //IN GENERAL
            //CheckDeptID

        //STAFF
        public static void checkInstructorBit(string name, ref List<string> errors)
        {

        }
        //IN GENERAL
            //CheckEmail
            //CheckName
            //CheckDeptID
            //CheckPassword
            //CheckStaffID

        //COURSE SCHEDULE
        public static void checkYear(string name, ref List<string> errors)
        {

        }
        
        public static void checkQuarter(string name, ref List<string> errors)
        {

        }

        public static void checkSession(string name, ref List<string> errors)
        {

        }
        //IN GENERAL
            //CheckCourseID
            //CheckStaffID
            //CheckScheduleID
            //CheckScheduleDayID
            //CheckScheduleTimeID

        //SCHEDULE DAY
        public static void checkScheduleDay(string name, ref List<string> errors)
        {

        }
        //IN GENERAL
            //CheckScheduleDayID

        //******************* SCHEDULE TIME *******************
        public static void checkScheduleTime(string name, ref List<string> errors)
        {

        }
        //IN GENERAL
            //CheckScheduleTimeID

        //COURSE
        public static void checkCourseTitle(string name, ref List<string> errors)
        {

        }

        public static void checkCourseLevel(string name, ref List<string> errors)
        {

        }

        public static void checkCourseDescription(string name, ref List<string> errors)
        {

        }

        public static void checkCourseUnits(string name, ref List<string> errors)
        {

        }
        //IN GENERAL
            //CheckCourseID

        //COURSE RULE
        //IN GENERAL
            //CheckCourseID
            //CheckCourseID for course_pre_id
    }
}
