using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using POCO;
using DAL;

namespace BL
{
    public static class BLCheck
    {
        //MAIN METHODS
        
        public static void checkStudentErrors(Student student, ref List<string> errors)
        {
            checkNullObject(student, ref errors);
            checkStudentID(student.id, ref errors);
            checkName(student.first_name, "student", ref errors);
            checkEmail(student.email, ref errors);
            checkPassword(student.password, ref errors);
            checkStudentSSN(student.ssn, ref errors);
            checkStudentShoeSize(student.shoe_size, ref errors);
            checkStudentWeight(student.weight, ref errors);
            checkMajorID(student.major, ref errors);
            checkStudentLevel(student.level, ref errors);
            for (int i = 0; i < student.enrolled.Count; i++) {
                checkScheduleErrors(student.enrolled[i], ref errors);
            }
        }

        public static void checkStaffErrors(Staff staff, ref List<string> errors)
        {
            checkNullObject(staff, ref errors);
            checkName(staff.first_name, "first", ref errors);
            checkName(staff.last_name, "last", ref errors);
            checkEmail(staff.email, ref errors);
            checkPassword(staff.email, ref errors);
            checkDepartmentErrors(staff.dept, ref errors);

        }
        
        public static void checkCourseErrors(Course course, ref List<string> errors)
        {
        
        }
       
        public static void checkDepartmentErrors(Department dept, ref List<string> errors)
        {
            checkNullObject(dept, ref errors);
            checkDeptName(dept.deptName, ref errors);
            checkDeptID(dept.id, ref errors);
            checkChairID(dept.chairID, ref errors);
        }
        
        public static void checkMajorErrors(Major major, ref List<string> errors)
        {
        
        }
       
        public static void checkScheduleErrors(ScheduledCourse sCourse, ref List<string> errors)
        {
        
        }
        
        public static void checkEnrollmentErrors(Enrollment enrolledCourse, ref List<string> errors)
        {
            checkNullObject(enrolledCourse, ref errors);
            checkScheduleErrors(enrolledCourse.ScheduledCourse, ref errors);
            checkGrade(enrolledCourse.grade, ref errors);
        }
        

        //GENERAL ERROR CHECKING
        static void checkNullObject(Object obj, ref List<string> errors)
        {
            if (obj == null)
            {
                errors.Add("Cannot insert or update a null object.");
            }
        }
        static void checkEmail(string email, ref List<string> errors)
        {
            if (email != null && email.Length <= 50)
            {
                string strRegex = @"\A(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*@(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?)\Z";
                if (!Regex.IsMatch(email, strRegex))
                    errors.Add("The student email format is incorrect");
            } 
        }

        static void checkName(string name, string FirstOrLast, ref List<string> errors)
        {
            if (name == null)
                errors.Add(FirstOrLast + " name cannot be null");
            else if (name == "")
                errors.Add(FirstOrLast + " name cannot be empty");
            else if (name.Length > 50)
                errors.Add(FirstOrLast + " name cannot greater than 50 characters");
        }

        static void checkFirstName(string name, ref List<string> errors)
        {
            checkName(name, "First", ref errors);
        }

        static void checkLastName(string name, ref List<string> errors)
        {
            checkName(name, "Last", ref errors);
        }

        static void checkPassword(string password, ref List<string> errors)
        {
            if (password == null)
                errors.Add("password cannot be null");
            else if (password == "")
                errors.Add("password cannot be empty");
            else if (password.Length > 15 || password.Length < 8)
                errors.Add("password length cannot exceed 15 characters or be less than 8 characters");
        }

        static void checkID(int id, string tableName, ref List<string> errors)
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
        public static void checkStudentLevel(StudentLevel level, ref List<string> errors)
        {
            if (level == null)
            {
                errors.Add("Student level cannot be null.");
            }
            else if (level.Equals("freshman") || level.Equals("sophomore") || level.Equals("junior") || 
                     level.Equals("senior") || level.Equals("grad") || level.Equals("phd")) {
                         errors.Add("Student level cannot be anything other than: 'freshman', 'sophomore', 'junior'," +
                                     "'senior', 'grad', or 'phd'.");
            }
        }

        public static void checkStudentStatus(int status, ref List<string> errors)
        {
            if (status < 0)
            {
                errors.Add("Student cannot have a null.");
            }
        }

        public static void checkStudentShoeSize(float shoeSize, ref List<string> errors)
        {

        }

        public static void checkStudentWeight(int weight, ref List<string> errors)
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
        public static void checkGrade(string grade, ref List<string> errors)
        {
            if (grade == null)
            {
                errors.Add("Grade cannot be null");
            }
            else if (grade == "")
            {
                errors.Add("Grade cannot be empty");
            }
            else if (grade.Length > 50)
            {
                errors.Add("Grade cannot be more than 50");
            }
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
        public static void checkChairID(int id, ref List<string> errors)
        {
            checkID(id, "Chair", ref errors);
        }

        public static void checkDeptName(string name, ref List<string> errors)
        {
            if (name == null)
            {
                errors.Add("Department name cannot be null");
            }
            else if (name == "")
            {
                errors.Add("Department name cannot be empty");
            }
            else if (name.Length > 50)
            {
                errors.Add("Department name cannot be more than 50");
            }
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
        public static void checkScheduleDay(string day, ref List<string> errors)
        {
            if (day == null)
            {
                errors.Add("Day cannot be null");
            }
            else if (day == "")
            {
                errors.Add("Day cannot be empty");
            }
            else if (day.Length > 50)
            {
                errors.Add("Day cannot be more than 50");
            }
        }
        //IN GENERAL
            //CheckScheduleDayID

        //******************* SCHEDULE TIME *******************
        public static void checkScheduleTime(string time, ref List<string> errors)
        {
            if (time == null)
            {
                errors.Add("Time cannot be null");
            }
            else if (time == "")
            {
                errors.Add("Time cannot be empty");
            }
            else if (time.Length > 50)
            {
                errors.Add("Time cannot be more than 50");
            }
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
