using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using POCO;
using BL;

namespace BLTest
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class BLStaffTest
    {
        public BLStaffTest()
        {
            //
            // TODO: Add constructor logic here
            //
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Gets or sets the test context which provides
        ///information about and functionality for the current test run.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        [TestMethod]
        public void InsertStaffErrorTest()
        {
            List<string> errors = new List<string>();

            int newStaffID;
            //Should catch the null object error
            BLStaff.InsertStaff(null, ref errors, out newStaffID);
            Assert.AreEqual(1, errors.Count);

            errors = new List<string>();

            Staff instructor = new Staff();
            instructor.first_name = "";// fail, empty string
            instructor.last_name = null;// fail, null
            instructor.email = "staff@....edu";//fail, regex
            instructor.password = "password123456789";// fail, > 15 chars
            instructor.dept = new Department();
            instructor.dept.chairID = -1;// fail, negative ID
            instructor.dept.deptName = "";// fail, empty string
            instructor.isInstructor = true;// impossible to fail.

            //Should catch the regEx for email, invalid formatting error
            BLStaff.InsertStaff(instructor, ref errors, out newStaffID);
            instructor.id = newStaffID;//assigning the auto-inc staff_id to this instructor object
            Assert.AreEqual(6, errors.Count);

        }

        [TestMethod]
        public void GetStaffErrorTest()
        {
            List<string> errors = new List<string>();

            BLStaff.GetStaff(-5, ref errors);
            Assert.AreEqual(1, errors.Count);
        }

        [TestMethod]
        public void DeleteStaffErrorTest()
        {
            List<string> errors = new List<string>();

            BLStudent.DeleteStudent(null, ref errors);
            Assert.AreEqual(1, errors.Count);
        }

        [TestMethod]
        public void StaffInsertAndSelectTest()
        {
            Student student = new Student();
            int studentID;
            student.first_name = "first";
            student.last_name = " last";
            student.id = Guid.NewGuid().ToString().Substring(0, 20);
            student.ssn = "777777777";
            student.email = "myemail97@ucsd.edu";
            student.password = "pass1234";
            student.shoe_size = 0;
            student.weight = 0;
            student.major = 1;
            student.level = 0;
            student.status = 0;
            student.enrolled = new List<ScheduledCourse>();

            List<string> errors = new List<string>();
            BLStudent.InsertStudent(student, ref errors);
            student.id = studentID;
            Assert.AreEqual(0, errors.Count);

            Student verifyStudent = BLStudent.GetStudent(student.id, ref errors);

            Assert.AreEqual(0, errors.Count);
            Assert.AreEqual(student.first_name, verifyStudent.first_name);
            Assert.AreEqual(student.last_name, verifyStudent.last_name);
            Assert.AreEqual(student.id, verifyStudent.id);
            Assert.AreEqual(student.ssn, verifyStudent.ssn);
            Assert.AreEqual(student.email, verifyStudent.email);
            Assert.AreEqual(student.shoe_size, verifyStudent.shoe_size);
            Assert.AreEqual(student.weight, verifyStudent.weight);
            Assert.AreEqual(student.major, verifyStudent.major);
            Assert.AreEqual(student.level, verifyStudent.level);
            Assert.AreEqual(student.status, verifyStudent.status);

            /*
            //List<ScheduledCourse> scheduleList = BLSchedule.GetScheduleList("", "", ref errors); // This was the original code.
            List<ScheduledCourse> scheduleList = BLSchedule.GetScheduleList(2011, "Fall", ref errors);//JUSTIN ADDED THIS FOR DUBUG PURPOSES
            Assert.AreEqual(0, errors.Count);

            // enroll all available scheduled courses for this student
            for (int i = 0; i < scheduleList.Count; i++)
            {
                student.enrolled.Add(scheduleList[i]);// JUSTIN : for testing purposes. Will compare this with the List<ScheduledCourse>.
                //System.Diagnostics.Debug.WriteLine("Added a course to student course schedule: " + student.enrolled[i].course.title);//JUSTIN ADDED THIS

                BLStudent.EnrollSchedule(student.id, scheduleList[i].id, ref errors);
                //System.Diagnostics.Debug.WriteLine("Added a course to scheduleList: " + scheduleList[i].course.title);//JUSTIN ADDED THIS
                Assert.AreEqual(0, errors.Count);
            }

            // JUSTIN : Extra test to ensure that ALL the courses from the selected course schedule were added, verifies by count.
            System.Diagnostics.Debug.WriteLine("scheduleList size: " + scheduleList.Count + "\nStudent schedule size: " + student.enrolled.Count);//JUSTIN ADDED THIS
            Assert.AreEqual(scheduleList.Count, student.enrolled.Count);

            // drop all available scheduled courses for this student
            for (int i = 0; i < scheduleList.Count; i++)
            {
                BLStudent.DropEnrolledSchedule(student.id, scheduleList[i].id, ref errors);
                // This is not an accurate test because it doesn't verify that the student's enrollment schedule is empty.
                Assert.AreEqual(0, errors.Count);
                student.enrolled.Remove(scheduleList[i]);// JUSTIN : to use in the following assertion.
            }
            Assert.AreEqual(0, student.enrolled.Count);// JUSTIN : This makes sure that the student's enroll Sched is empty.

            /* JUSTIN : now the student object is up-to-date, including their course schedule.
             * NOTE: I think we should always keep the object updated, through every method acting upon it. Yeah? No?
             * */
            BLStudent.DeleteStudent(student.id, ref errors);

            Student verifyEmptyStudent = BLStudent.GetStudent(student.id, ref errors);
            Assert.AreEqual(0, errors.Count);
            Assert.AreEqual(null, verifyEmptyStudent);

        }

    }
}
