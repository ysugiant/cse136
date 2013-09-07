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
    public class DALEnrollmentTest
    {
        public DALEnrollmentTest()
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
        public void EnrollmentTest()
        {
            List<string> errors = new List<string>();

            Student student = new Student();
            student.id = Guid.NewGuid().ToString().Substring(0, 20); // use the existing student ID 
            student.first_name = "first2";
            student.last_name = " last2";
            student.ssn = "777664321";
            student.email = "myemail2@ucsd.edu";
            student.password = "pass1234";
            student.shoe_size = 2;
            student.weight = 2;
            student.major = 1;//JUSTIN ADDED THIS
            //student.level = StudentLevel.senior;//JUSTIN ADDED THIS
            student.level = "senior";//JUSTIN ADDED THIS
            student.status = 0;//JUSTIN ADDED THIS

            //System.Diagnostics.Debug.WriteLine("value of student.level is: " + student.level.ToString());
            DALStudent.InsertStudent(student, ref errors);

            List<ScheduledCourse> scheduleList = DALCourseSchedule.GetCourseScheduleList(0, "", ref errors);
            Assert.AreEqual(0, errors.Count);
            System.Diagnostics.Debug.WriteLine("pass1");
            // enroll all available scheduled courses for this student
            for (int i = 0; i < scheduleList.Count; i++)
            {
                // this enrolls the student into one course at a time, hence the for loop
                DALEnrollment.InsertEnrollment(student.id, scheduleList[i].id, ref errors);
                Assert.AreEqual(0, errors.Count);
            }
            System.Diagnostics.Debug.WriteLine("pass1");
            //updating grade
            for (int i = 0; i < scheduleList.Count; i++)
            {
                DALEnrollment.UpdateEnrollment(student.id, scheduleList[i].id, "Aplus", ref errors);
                Assert.AreEqual(0, errors.Count);
            }

            //get enroll data
            List<Enrollment> trans = DALEnrollment.GetEnrollment(ref errors);
            Assert.AreEqual(0, errors.Count);
            System.Diagnostics.Debug.WriteLine("pass1");
            //compare the result
            for (int i = 0; i < trans.Count; i++)
            {
                System.Diagnostics.Debug.WriteLine(trans[i].grade);
                Assert.AreEqual(trans[i].grade, "Aplus");
            }
            System.Diagnostics.Debug.WriteLine("pass5");

            // drop all available scheduled courses for this student
            for (int i = 0; i < scheduleList.Count; i++)
            {
                DALEnrollment.DeleteEnrollment(student.id, scheduleList[i].id, ref errors);
                Assert.AreEqual(0, errors.Count);
            }

            DALStudent.DeleteStudent(student.id, ref errors);
        }

    }
}
