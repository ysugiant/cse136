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
            List<string> errors = new List<string>(); //ERRORS list

            //MALFORMED POCOS
            //errors.Add("Year cannot be greater than 2013"); [4 errors]
            ScheduledCourse schedYearGreater = new ScheduledCourse();
            schedYearGreater.course = new Course();
            schedYearGreater.year = 2017;
            schedYearGreater.quarter = "Fall";
            schedYearGreater.session = "A1B";
            schedYearGreater.course.id = -4;
            schedYearGreater.instr_id = 61;
            schedYearGreater.timeID = -3;
            schedYearGreater.dayID = 3;

            //errors.Add("Year cannot be less than 1950"); [4 errors]
            ScheduledCourse schedYearLesser = new ScheduledCourse();
            schedYearLesser.course = new Course();
            schedYearLesser.year = 100;
            schedYearLesser.quarter = "Fall";
            schedYearLesser.session = "";
            schedYearLesser.course.id = 1;
            schedYearLesser.instr_id = -61;
            schedYearLesser.timeID = 2;
            schedYearLesser.dayID = -3;

            //errors.Add("Quarter is invalid"); [2 errors]
            ScheduledCourse schedQuarter = new ScheduledCourse();
            schedQuarter.course = new Course();
            schedQuarter.year = 2012;
            schedQuarter.quarter = "Autumn";
            schedQuarter.session = "123";
            schedQuarter.course.id = 1;
            schedQuarter.instr_id = 61;
            schedQuarter.timeID = 2;
            schedQuarter.dayID = 3;

            //errors.Add("The session format is incorrect"); [1 error]
            ScheduledCourse schedSession = new ScheduledCourse();
            schedSession.course = new Course();
            schedSession.year = 2013;
            schedSession.quarter = "Spring";
            schedSession.session = "ABC";
            schedSession.course.id = 1;
            schedSession.instr_id = 61;
            schedSession.timeID = 2;
            schedSession.dayID = 3;

            //errors.Add("The session format is incorrect"); [1 error]
            ScheduledCourse schedSession2 = new ScheduledCourse();
            schedSession2.course = new Course();
            schedSession2.year = 2013;
            schedSession2.quarter = "Spring";
            schedSession2.session = null;
            schedSession2.course.id = 1;
            schedSession2.instr_id = 61;
            schedSession2.timeID = 2;
            schedSession2.dayID = 3;

            //INSERT 1
            int ID1;
            BLCourseSchedule.InsertCourseSchedule(schedYearGreater, ref errors, out ID1);
            schedYearGreater.id = ID1;
            Assert.AreEqual(4, errors.Count);

            //INSERT 2
            int ID2;
            BLCourseSchedule.InsertCourseSchedule(schedYearLesser, ref errors, out ID2);
            schedYearLesser.id = ID2;
            Assert.AreEqual(8, errors.Count);

            //INSERT 3
            int ID3;
            BLCourseSchedule.InsertCourseSchedule(schedQuarter, ref errors, out ID3);
            schedQuarter.id = ID3;
            Assert.AreEqual(10, errors.Count);

            //VERIFY, GET 
            //Get with a negative value for course_schedule id
            ScheduledCourse verifyEmptyCourseSchedule = BLCourseSchedule.GetCourseScheduleDetail(schedYearGreater.id, ref errors);
            Assert.AreEqual(11, errors.Count);
            Assert.AreEqual(null, verifyEmptyCourseSchedule);

            //DELETE
            //Delete with a negative value for course_schedule id
            BLCourseSchedule.DeleteCourseSchedule(schedYearLesser.id, ref errors);
            Assert.AreEqual(12, errors.Count);

            BLCourseSchedule.DeleteCourseSchedule(schedQuarter.id, ref errors);
            Assert.AreEqual(13, errors.Count);

            //UPDATE
            BLCourseSchedule.UpdateCourseSchedule(schedSession, ref errors);
            Assert.AreEqual(14, errors.Count);
            BLCourseSchedule.UpdateCourseSchedule(schedSession2, ref errors);
            Assert.AreEqual(15, errors.Count);
        }
    }
}
