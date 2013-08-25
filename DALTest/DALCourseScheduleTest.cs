using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DAL;
using POCO;

namespace DALTest
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    class DALCourseScheduleTest2
    {
        static ScheduledCourse sCourse = null;
        static ScheduledCourse sCourse2 = null;

        public DALCourseScheduleTest2()
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
        /*
        [ClassInitialize()]
        public static void MyClassInitialize(TestContext testContext)
        {
            sCourse = new ScheduledCourse();
            //sCourse.id = auto incremented
            sCourse.course.id = "1";
            sCourse.year = 2013;
            sCourse.quarter = "Spring";
            sCourse.session = "A00";
            sCourse.dayID = 2;
            sCourse.instr_id = 1;
            sCourse.timeID = 13;

            sCourse2 = new ScheduledCourse();
            //sCourse.id = auto incremented
            sCourse2.course.id = "2";
            sCourse2.year = 2013;
            sCourse2.quarter = "Summer 1";
            sCourse2.session = "A00";
            sCourse2.dayID = 1;
            sCourse2.instr_id = 1;
            sCourse2.timeID = 17;
        }*/
        #endregion

        [TestMethod]
        public void InsertCourseScheduleTest()
        {
            //ScheduledCourse sCourse = null;

            sCourse = new ScheduledCourse();
            //sCourse.id = auto incremented
            sCourse.course.id = 1;
            sCourse.year = 2013;
            sCourse.quarter = "Spring";
            sCourse.session = "A00";
            sCourse.dayID = 2;
            sCourse.instr_id = 1;
            sCourse.timeID = 13;

            List<string> errors = new List<string>();
            int sqlID = DALCourseSchedule.InsertCourseSchedule(sCourse, ref errors);

            Assert.AreEqual(0, errors.Count);

            ScheduledCourse verifyCourseSchedule = DALCourseSchedule.GetCourseScheduleDetail(sqlID, ref errors);

            Assert.AreEqual(0, errors.Count);
            Assert.AreEqual(sCourse.id, verifyCourseSchedule.id);
            Assert.AreEqual(sCourse.course.id, verifyCourseSchedule.course.id);
            Assert.AreEqual(sCourse.year, verifyCourseSchedule.year);
            Assert.AreEqual(sCourse.quarter, verifyCourseSchedule.quarter);
            Assert.AreEqual(sCourse.session, verifyCourseSchedule.session);
            Assert.AreEqual(sCourse.dayID, verifyCourseSchedule.dayID);
            Assert.AreEqual(sCourse.instr_id, verifyCourseSchedule.instr_id);
            Assert.AreEqual(sCourse.timeID, verifyCourseSchedule.timeID);
        }

        [TestMethod]
        public void UpdateCourseScheduleTest()
        {
            //ScheduledCourse sCourse2 = null;

            sCourse2 = new ScheduledCourse();
            //sCourse.id = auto incremented
            sCourse2.course.id = 2;
            sCourse2.year = 2013;
            sCourse2.quarter = "Summer 1";
            sCourse2.session = "A00";
            sCourse2.dayID = 1;
            sCourse2.instr_id = 1;
            sCourse2.timeID = 17;

            List<string> errors = new List<string>();
            DALCourseSchedule.UpdateCourseSchedule(sCourse2, ref errors);

            Assert.AreEqual(0, errors.Count);

            ScheduledCourse verifyCourseSchedule = DALCourseSchedule.GetCourseScheduleDetail(sCourse2.id, ref errors);

            Assert.AreEqual(0, errors.Count);
            Assert.AreEqual(sCourse2.id, verifyCourseSchedule.id);
            Assert.AreEqual(sCourse2.course.id, verifyCourseSchedule.course.id);
            Assert.AreEqual(sCourse2.year, verifyCourseSchedule.year);
            Assert.AreEqual(sCourse2.quarter, verifyCourseSchedule.quarter);
            Assert.AreEqual(sCourse2.session, verifyCourseSchedule.session);
            Assert.AreEqual(sCourse2.dayID, verifyCourseSchedule.dayID);
            Assert.AreEqual(sCourse2.instr_id, verifyCourseSchedule.instr_id);
            Assert.AreEqual(sCourse2.timeID, verifyCourseSchedule.timeID);
        }

        [TestMethod]
        public void DeleteCourseScheduleTest()
        {
            List<string> errors = new List<string>();
            DALCourseSchedule.DeleteCourseSchedule(sCourse2.id, ref errors);

            ScheduledCourse verifyEmptyCourseSchedule = DALCourseSchedule.GetCourseScheduleDetail(sCourse2.id, ref errors);
            Assert.AreEqual(0, errors.Count);
            Assert.AreEqual(null, verifyEmptyCourseSchedule);
        }
    }
}
