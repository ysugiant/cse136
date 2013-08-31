﻿using System;
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
        public void BusinessLayerErrorTest()
        {
            //######################################TESTING INSERTION ERRORS#################################
            List<string> errors = new List<string>();

            int newStaffID;
            //Should catch the null object error
            BLStaff.InsertStaff(null, ref errors, out newStaffID);
            Assert.AreEqual(1, errors.Count);

            Staff instructor = new Staff();
            instructor.first_name = "";// fail, empty string
            instructor.last_name = null;// fail, null
            instructor.email = "staff@..!~<>.edu";//fail, regex
            instructor.password = "password123456789";// fail, > 15 chars
            instructor.dept = new Department();
            instructor.dept.id = -99;// fail, negative dept ID
            instructor.dept.chairID = -1;// fail, negative ID
            instructor.dept.deptName = "";// fail, empty string
            instructor.isInstructor = true;// impossible to fail.

            //Should catch 7 total errors...
            BLStaff.InsertStaff(instructor, ref errors, out newStaffID);
            instructor.id = newStaffID;//assigning the auto-inc staff_id to this instructor object
            Assert.AreEqual(7, errors.Count);

            errors.Clear();
            int newStaffID2;
            Staff instructor2 = new Staff();
            instructor2.first_name = null;// fail, null
            instructor2.last_name = "111111111111111111111111111111111111111111111111111111111111";// fail, too long
            instructor2.email = null;//fail, null
            instructor2.password = null;// fail, null
            instructor2.dept = new Department();
            instructor2.dept.id = 20;
            instructor2.dept.chairID = 177;
            instructor2.dept.deptName = null;// fail, null
            instructor2.isInstructor = true;// impossible to fail.

            //Should catch 5 total errors...
            BLStaff.InsertStaff(instructor2, ref errors, out newStaffID2);
            instructor2.id = newStaffID2;//assigning the auto-inc staff_id to this instructor object
            Assert.AreEqual(5, errors.Count);

            errors.Clear();
            int newStaffID3;
            Staff instructor3 = new Staff();
            instructor3.first_name = "George";
            instructor3.last_name = "Costanza";
            instructor3.email = "";//fail, empty
            instructor3.password = "";// fail, empty
            instructor3.dept = new Department();
            instructor3.dept.id = 20;
            instructor3.dept.chairID = 177;
            instructor3.dept.deptName = "SomeCrazyLongDepartmentNameThatShouldNotBeInTheDatabase";// fail, too long
            instructor3.isInstructor = false;// impossible to fail.

            //Should catch 3 total errors...
            BLStaff.InsertStaff(instructor3, ref errors, out newStaffID3);
            instructor3.id = newStaffID3;//assigning the auto-inc staff_id to this instructor object
            Assert.AreEqual(3, errors.Count);

            errors.Clear();
            int newStaffID4;
            Staff instructor4 = new Staff();
            instructor4.first_name = "George";
            instructor4.last_name = "Costanza";
            instructor4.email = "someilegitamatebullshitlongpasswordthatshouldnotbeinthedatabase@ucsd.edu";//fail, too long
            instructor4.password = "glorious";
            instructor4.dept = new Department();
            instructor4.dept.id = 20;
            instructor4.dept.chairID = 177;
            instructor4.dept.deptName = "Physics";
            instructor4.isInstructor = false;// impossible to fail.

            //Should catch 1 total error
            BLStaff.InsertStaff(instructor4, ref errors, out newStaffID4);
            instructor4.id = newStaffID4;//assigning the auto-inc staff_id to this instructor object
            Assert.AreEqual(1, errors.Count);

            //########################################TESTING SELECTION ERRORS##############################
            errors.Clear();// Resetting the errors log to begin anew.
            BLStaff.GetStaff(-5, ref errors);// should result in 1 error, id.
            Assert.AreEqual(1, errors.Count);

            //#######################################TESTING DELETION ERRORS###############################
            errors.Clear(); ;// Resetting the errors log to beging anew.
            BLStaff.DeleteStaff(-5, ref errors);// Can only fail on the one parameter, id.
            Assert.AreEqual(1, errors.Count);
        }

        [TestMethod]
        public void BusinessLayerStaffTest()
        {
            List<string> errors = new List<string>();

            //#######################################TESTING BLSTAFF FUNCTIONS############################
            Staff advisor = new Staff();
            int staffID;
            advisor.first_name = "first";
            advisor.last_name = " last";
            advisor.email = "myemail97@ucsd.edu";
            advisor.password = "pass1234";
            Department dept = new Department();
            dept.id = 20;
            dept.chairID = 177;
            dept.deptName = "Physics";
            advisor.dept = dept;
            advisor.isInstructor = false;

            BLStaff.InsertStaff(advisor, ref errors, out staffID);
            advisor.id = staffID;
            System.Diagnostics.Debug.WriteLine("The advisors new ID is: " + advisor.id);
            Assert.AreEqual(0, errors.Count);

            Staff verifyAdvisor = BLStaff.GetStaff(advisor.id, ref errors);
            Assert.AreEqual(0, errors.Count);

            Assert.AreEqual(advisor.id, verifyAdvisor.id);
            Assert.AreEqual(advisor.first_name, verifyAdvisor.first_name);
            Assert.AreEqual(advisor.last_name, verifyAdvisor.last_name);
            Assert.AreEqual(advisor.email, verifyAdvisor.email);
            Assert.AreEqual(advisor.password, verifyAdvisor.password);
            Assert.AreEqual(advisor.dept.id, verifyAdvisor.dept.id);
            Assert.AreEqual(advisor.isInstructor, verifyAdvisor.isInstructor);

            BLStaff.DeleteStaff(advisor.id, ref errors);

            Staff verifyEmptyAdvisor = BLStaff.GetStaff(advisor.id, ref errors);
            Assert.AreEqual(0, errors.Count);
            Assert.AreEqual(null, verifyEmptyAdvisor);
        }

        /*[TestMethod]
        public void GetStaffErrorTest()
        {
            List<string> errors = new List<string>();

            BLStaff.GetStaff(-5, ref errors);
            Assert.AreEqual(1, errors.Count);
        }*/

        /*[TestMethod]
        public void DeleteStaffErrorTest()
        {
            List<string> errors = new List<string>();

            BLStaff.DeleteStaff(null, ref errors);
            Assert.AreEqual(1, errors.Count);
        }*/

        /*[TestMethod]
        public void StaffInsertAndSelectTest()
        {
            List<string> errors = new List<string>();

            Staff advisor = new Staff();
            int staffID;
            advisor.first_name = "first";
            advisor.last_name = " last";
            advisor.email = "myemail97@ucsd.edu";
            advisor.password = "pass1234";
            advisor.dept = BLDepartment.GetDepartmentDetail("Computer Science and Engineering", ref errors);
            advisor.isInstructor = false;
            
            BLStaff.InsertStaff(advisor, ref errors, out staffID);
            advisor.id = staffID;
            Assert.AreEqual(0, errors.Count);

            Staff verifyAdvisor = BLStaff.GetStaff(advisor.id, ref errors);
            Assert.AreEqual(0, errors.Count);

            Assert.AreEqual(advisor.id, verifyAdvisor.id);
            Assert.AreEqual(advisor.first_name, verifyAdvisor.first_name);
            Assert.AreEqual(advisor.last_name, verifyAdvisor.last_name);
            Assert.AreEqual(advisor.email, verifyAdvisor.email);
            Assert.AreEqual(advisor.password, verifyAdvisor.password);
            Assert.AreEqual(advisor.dept.id, verifyAdvisor.dept.id);
            Assert.AreEqual(advisor.isInstructor, verifyAdvisor.isInstructor);

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
            /*BLStaff.DeleteStaff(advisor.id, ref errors);

            Staff verifyEmptyAdvisor = BLStaff.GetStaff(advisor.id, ref errors);
            Assert.AreEqual(0, errors.Count);
            Assert.AreEqual(null, verifyEmptyAdvisor);*/

        //}

    }
}
