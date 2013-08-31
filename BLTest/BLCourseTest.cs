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
    public class BLCourseTest
    {
        public BLCourseTest()
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
        public void InsertCourseErrorTest()
        {
            List<string> errors = new List<string>();

            BLCourse.InsertCourse(null, ref errors);
            //BLCOurse check all of them
            Assert.AreEqual(1, errors.Count);

            errors = new List<string>();

            Course course = new Course();
            course.id = -1;
            course.title = "";
            course.description = "";
            course.units = -1;
            BLCourse.InsertCourse(course, ref errors);
            Assert.AreEqual(4, errors.Count);

            /*
            errors = new List<string>();
            course = new Course();
            course.title = "";
            BLCourse.InsertCourse(course, ref errors);
            Assert.AreEqual(1, errors.Count);


            errors = new List<string>();
            course = new Course();
            course = "";
            BLCourse.InsertCourse(course, ref errors);
            Assert.AreEqual(1, errors.Count);
             */


        }

        [TestMethod]
        public void GetCourseErrorTest()
        {
            List<string> errors = new List<string>();

            BLCourse.GetCourse(null, ref errors);
            Assert.AreEqual(1, errors.Count);

            errors = new List<string>();
            String coursetitle = "";
            BLCourse.GetCourse(coursetitle, ref errors);
            Assert.AreEqual(1, errors.Count);

        }

        [TestMethod]
        public void DeleteCourseErrorTest()
        {
            List<string> errors = new List<string>();

            BLCourse.GetCourse(null, ref errors);
            Assert.AreEqual(1, errors.Count);

            errors = new List<string>();
            String coursetitle = "";
            BLCourse.DeleteCourse(coursetitle, ref errors);
            Assert.AreEqual(1, errors.Count);
        }

        [TestMethod]
        public void InsertPrerequisiteErrorTest()
        {
            List<string> errors = new List<string>();

            int courseid = -1;
            int course_pre_id = -1;

            BLCourse.InsertPrerequisite(courseid, course_pre_id, ref errors);
            Assert.AreEqual(2, errors.Count);
        }

        [TestMethod]
        public void UpdatePrerequisiteErrorTest()
        {
            List<string> errors = new List<string>();

            int courseid = -1;
            int course_pre_id = -1;
            int change_id = -1;

            BLCourse.UpdatePrerequisite(courseid, course_pre_id, change_id, ref errors);
            Assert.AreEqual(3, errors.Count);
        }

        [TestMethod]
        public void DeletePrerequisiteErrorTest()
        {
            List<string> errors = new List<string>();

            int courseid = -1;
            int course_pre_id = -1;

            BLCourse.DeletePrerequisite(courseid, course_pre_id, ref errors);
            Assert.AreEqual(2, errors.Count);
        }





        [TestMethod]
        public void BusinessLayerCourseTest()
        {
            Course course = new Course();
            course.title = "BL CSE TEST";
            course.level = (CourseLevel)Enum.Parse(typeof(CourseLevel), "grad");
            course.description = "test insert course";
            course.units = 10;

            List<string> errors = new List<string>();
            BLCourse.InsertCourse(course, ref errors);

            Assert.AreEqual(0, errors.Count);

            Course verifyCourse = BLCourse.GetCourse(course.title, ref errors);
            //Assert.AreEqual(student.ToString(),verifyStudent.ToString());
            Assert.AreEqual(0, errors.Count);
            Assert.AreEqual(course.title, verifyCourse.title);
            Assert.AreEqual(course.level, verifyCourse.level);
            Assert.AreEqual(course.description, verifyCourse.description);
            Assert.AreEqual(course.units, verifyCourse.units);



            Course course2 = new Course();
            course2.id = BLCourse.GetCourse(course.title, ref errors).id;
            course2.title = "BL CSE TEST TWO";
            course2.level = (CourseLevel)Enum.Parse(typeof(CourseLevel), "lower");
            course2.description = "test insert course 2";
            course2.units = 10;

            BLCourse.UpdateCourse(course2, ref errors);

            verifyCourse = BLCourse.GetCourse(course2.title, ref errors);
            Assert.AreEqual(0, errors.Count);
            //   Assert.AreEqual(course2.id, verifyCourse.id);
            Assert.AreEqual(course2.title, verifyCourse.title);
            Assert.AreEqual(course2.level, verifyCourse.level);
            Assert.AreEqual(course2.description, verifyCourse.description);
            Assert.AreEqual(course2.units, verifyCourse.units);



            // need to modify!!!!!


            List<Course> courseList = BLCourse.GetCourseList(ref errors);
            Assert.AreEqual(0, errors.Count);

            // enroll all available scheduled courses for this student
            for (int i = 0; i < courseList.Count; i++)
            {
                BLCourse.InsertPrerequisite(BLCourse.GetCourse(course2.title, ref errors).id, courseList[i].id, ref errors);
                Assert.AreEqual(0, errors.Count);
            }

            // drop all available scheduled courses for this student
            for (int i = 0; i < courseList.Count; i++)
            {
                BLCourse.DeletePrerequisite(BLCourse.GetCourse(course2.title, ref errors).id, courseList[i].id, ref errors);
                Assert.AreEqual(0, errors.Count);
            }

            BLCourse.DeleteCourse(course.title, ref errors);
            BLCourse.DeleteCourse(course2.title, ref errors);
            Course verifyEmptyStudent = BLCourse.GetCourse(course2.title, ref errors);
            Assert.AreEqual(0, errors.Count);
            Assert.AreEqual(null, verifyEmptyStudent);


        }

    }
}
