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
            List<string> errors = new List<string>();

            //INSERT        InsertCourseSchedule(ScheduledCourse sched, ref List<string> errors)            
            ScheduledCourse sCourse = new ScheduledCourse();
            sCourse.course = new Course();
            
            sCourse.year = 2013;
            sCourse.quarter = "Fall";
            sCourse.session = "A01";
            sCourse.course.id = 1;
            sCourse.timeID = 2;
            sCourse.dayID = 3;
            sCourse.instr_id = 1;
            
            int ID;
            BLCourseSchedule.InsertCourseSchedule(sCourse, ref errors, out ID);
            sCourse.id = ID;
            
            //check for errors:
            Assert.AreEqual(0, errors.Count);

            //VERIFY, GET
            ScheduledCourse verifyCourseSchedule = BLCourseSchedule.GetCourseScheduleDetail(ID, ref errors);

            //check for errors:
            Assert.AreEqual(0, errors.Count);
            Assert.AreEqual(sCourse.id, verifyCourseSchedule.id);
            Assert.AreEqual(sCourse.course.id, verifyCourseSchedule.course.id);
            Assert.AreEqual(sCourse.year, verifyCourseSchedule.year);
            Assert.AreEqual(sCourse.quarter, verifyCourseSchedule.quarter);
            Assert.AreEqual(sCourse.session, verifyCourseSchedule.session);
            Assert.AreEqual(sCourse.dayID, verifyCourseSchedule.dayID);
            Assert.AreEqual(sCourse.instr_id, verifyCourseSchedule.instr_id);
            Assert.AreEqual(sCourse.timeID, verifyCourseSchedule.timeID);

            //UPDATE        UpdateCourseSchedule(ScheduledCourse sched, ref List<string> errors)
            ScheduledCourse sCourse2 = new ScheduledCourse();
            sCourse2.course = new Course();
            sCourse2.id = sCourse.id;
            sCourse2.year = 2013;
            sCourse2.quarter = "Summer 1";
            sCourse2.session = "A09";
            sCourse2.course.id = 1;
            sCourse2.timeID = 2;
            sCourse2.dayID = 3;
            sCourse2.instr_id = 1;

            BLCourseSchedule.UpdateCourseSchedule(sCourse2, ref errors);

            //check for errors:
            Assert.AreEqual(0, errors.Count);

            verifyCourseSchedule = BLCourseSchedule.GetCourseScheduleDetail(sCourse2.id, ref errors);

            //check for errors:
            Assert.AreEqual(0, errors.Count);

            Assert.AreEqual(sCourse2.id, verifyCourseSchedule.id);
            Assert.AreEqual(sCourse2.course.id, verifyCourseSchedule.course.id);
            Assert.AreEqual(sCourse2.year, verifyCourseSchedule.year);
            Assert.AreEqual(sCourse2.quarter, verifyCourseSchedule.quarter);
            Assert.AreEqual(sCourse2.session, verifyCourseSchedule.session);
            Assert.AreEqual(sCourse2.dayID, verifyCourseSchedule.dayID);
            Assert.AreEqual(sCourse2.instr_id, verifyCourseSchedule.instr_id);
            Assert.AreEqual(sCourse2.timeID, verifyCourseSchedule.timeID);

            //DELETE 
            BLCourseSchedule.DeleteCourseSchedule(sCourse2.id, ref errors);

            ScheduledCourse verifyEmptyCourseSchedule = BLCourseSchedule.GetCourseScheduleDetail(sCourse2.id, ref errors);
            Assert.AreEqual(0, errors.Count);
            Assert.AreEqual(null, verifyEmptyCourseSchedule);
        }

        [TestMethod]
        public void BusinessLayerCourseScheduleErrorTest()
        {

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
        }
    }
}
