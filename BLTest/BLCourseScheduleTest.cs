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
    public class BLCourseScheduleTest
    {
        public BLCourseScheduleTest()
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

        #region Additional test attributes
        //
        // You can use the following additional attributes as you write your tests:
        //
        // Use ClassInitialize to run code before running the first test in the class
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Use ClassCleanup to run code after all tests in a class have run
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Use TestInitialize to run code before running each test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Use TestCleanup to run code after each test has run
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion

        [TestMethod]
        public void BusinessLayerCourseScheduleTest()
        {
            //INSERT        InsertCourseSchedule(ScheduledCourse sched, ref List<string> errors)            
            ScheduledCourse sCourse = new ScheduledCourse();
            Course course = new Course();
            
            sCourse.year = 2013;
            sCourse.quarter = "Fall";
            sCourse.session = "A01";
            sCourse.course.id = 1;
            sCourse.timeID = 2;
            sCourse.dayID = 3;
            sCourse.instr_id = 1;
           
            List<string> errors = new List<string>();
            int ID = 0;
            BLCourseSchedule.InsertCourseSchedule(sCourse, ref errors, out ID);
            sCourse.id = ID;
            Assert.AreEqual(0, errors.Count);



            //INSERT        InsertCourseSchedule(ScheduledCourse sched, ref List<string> errors)
            //checkYear//checkScheduleID//checkYear//checkQuarter
            //checkSession//checkCourseID//checkScheduleTimeID
            //checkScheduleDayID//checkStaffID

            //UPDATE        UpdateCourseSchedule(ScheduledCourse sched, ref List<string> errors)
            //checkYear
            //checkQuarter
            //checkSession
            //checkCourseID
            //checkStaffID
            //checkScheduleID
            //checkScheduleDayID
            //checkScheduleTimeID

            //DELETE        DeleteCourseSchedule(int id, ref List<string> errors)
            //checkScheduleID

            //GET           GetCourseScheduleDetail(int id, ref List<string> errors)
            //checkScheduleID

            //GET LIST      GetCourseScheduleList(int year, string quarter, ref List<string> errors)
            //checkYear
            //checkQuarter


            /*
            List<string> errors = new List<string>();

            BLStudent.InsertStudent(null, ref errors);
            Assert.AreEqual(1, errors.Count);

            errors = new List<string>();

            Student student = new Student();
            student.id = "";
            BLStudent.InsertStudent(student, ref errors);
            Assert.AreEqual(1, errors.Count); */
        }

        [TestMethod]
        public void BusinessLayerCourseScheduleErrorTest()
        {

        }
    }
}
