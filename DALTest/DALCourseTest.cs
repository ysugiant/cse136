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
    public class DALCourseTest
    {
        public DALCourseTest()
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

        /// <summary>
        ///A test for InsertStudent
        ///</summary>
        [TestMethod]
        public void InsertCourseTest()
        {
            //System.Diagnostics.Debug.WriteLine("Yay!");
            //student has 11 fields, and one list of <Schedule>'s
            Course course = new Course();
            course.title = "CSE TEST";
            course.level = (CourseLevel)Enum.Parse(typeof(CourseLevel),"grad");
            course.description = "test insert course";
            course.units = 10;
          
            List<string> errors = new List<string>();
            DALCourse.InsertCourse(course, ref errors);

            Assert.AreEqual(0, errors.Count);

            Course verifyCourse = DALCourse.GetCourseDetail(course.title, ref errors);
            //Assert.AreEqual(student.ToString(),verifyStudent.ToString());
            Assert.AreEqual(0, errors.Count);
            Assert.AreEqual(course.title, verifyCourse.title);
            Assert.AreEqual(course.level, verifyCourse.level);
            Assert.AreEqual(course.description, verifyCourse.description);
            Assert.AreEqual(course.units, verifyCourse.units);
            
            

            Course course2 = new Course();
            course2.id =  DALCourse.GetCourseDetail(course.title, ref errors).id;
            course2.title = "CSE TEST TWO";
            course2.level = (CourseLevel)Enum.Parse(typeof(CourseLevel), "lower");
            course2.description = "test insert course 2";
            course2.units = 20;

            DALCourse.UpdateCourse(course2, ref errors);
           
            verifyCourse = DALCourse.GetCourseDetail(course2.title, ref errors);
            Assert.AreEqual(0, errors.Count);
         //   Assert.AreEqual(course2.id, verifyCourse.id);
            Assert.AreEqual(course2.title, verifyCourse.title);
            Assert.AreEqual(course2.level, verifyCourse.level);
            Assert.AreEqual(course2.description, verifyCourse.description);
            Assert.AreEqual(course2.units, verifyCourse.units);



            // need to modify!!!!!


            List<Course> courseList = DALCourse.GetCourseList( ref errors);
            Assert.AreEqual(0, errors.Count);

            // enroll all available scheduled courses for this student
            for (int i = 0; i < courseList.Count; i++)
            {
                DALCourse.InsertPrerequisite(DALCourse.GetCourseDetail(course2.title, ref errors).id, courseList[i].id, ref errors);
                Assert.AreEqual(0, errors.Count);
            }

            // drop all available scheduled courses for this student
            for (int i = 0; i < courseList.Count; i++)
            {
                DALCourse.DeletePrerequisite(DALCourse.GetCourseDetail(course2.title, ref errors).id, courseList[i].id, ref errors);
                Assert.AreEqual(0, errors.Count);
            }

            DALCourse.DeleteCourse(course.title, ref errors);
            DALCourse.DeleteCourse(course2.title, ref errors);
            Course verifyEmptyStudent = DALCourse.GetCourseDetail(course2.title, ref errors);
            Assert.AreEqual(0, errors.Count);
            Assert.AreEqual(null, verifyEmptyStudent);

        }
    }
}
