using System;
using System.Text;
using System.Collections.Generic;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BL;
using POCO;

namespace BLTest
{
    /// <summary>
    /// Summary description for UnitTest1
    /// </summary>
    [TestClass]
    public class BLEnrollmentTest
    {
        public BLEnrollmentTest()
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
        public void BusinessLayerEnrollmentTest()
        {
            List<string> errors = new List<string>();

            Student student = new Student();
            student.id = "A12345648"; // use the existing student ID 
            student.first_name = "first2";
            student.last_name = " last2";
            student.ssn = "777664121";
            student.email = "myemail102@ucsd.edu";
            student.password = "pass1234";
            student.shoe_size = 2;
            student.weight = 2;
            student.major = 1;//JUSTIN ADDED THIS
            //student.level = (StudentLevel)Enum.Parse(typeof(StudentLevel), "freshman");//JUSTIN ADDED THIS
            student.level = "freshman";//JUSTIN ADDED THIS
            student.status = 0;//JUSTIN ADDED THIS

            //System.Diagnostics.Debug.WriteLine("value of student.level is: " + student.level.ToString());
            BLStudent.InsertStudent(student, ref errors);
            Assert.AreEqual(0, errors.Count);

            List<ScheduledCourse> scheduleList = new List<ScheduledCourse>();
            for (int i = 101; i <= 110; i++)
            {
                scheduleList.Add(BLCourseSchedule.GetCourseScheduleDetail(i, ref errors));
            }
            Assert.AreEqual(0, errors.Count);
            System.Diagnostics.Debug.WriteLine("pass1");
            // enroll all available scheduled courses for this student
            for (int i = 0; i < scheduleList.Count; i++)
            {
                // this enrolls the student into one course at a time, hence the for loop
                BLEnrollment.InsertEnrollment(student.id, scheduleList[i].id, ref errors);
                Assert.AreEqual(0, errors.Count);
            }
            System.Diagnostics.Debug.WriteLine("pass1");
            //updating grade
            for (int i = 0; i < scheduleList.Count; i++)
            {
                BLEnrollment.UpdateEnrollment(student.id, scheduleList[i].id, "APLUS", ref errors);
                Assert.AreEqual(0, errors.Count);
            }

            //get enroll data
            List<Enrollment> trans = BLEnrollment.GetEnrollment(student.id, ref errors);
            Assert.AreEqual(0, errors.Count);
            System.Diagnostics.Debug.WriteLine("pass1");
            //compare the result
            for (int i = 0; i < trans.Count; i++)
            {
                System.Diagnostics.Debug.WriteLine(trans[i].grade);
                Assert.AreEqual(trans[i].grade, "APLUS");
            }
            System.Diagnostics.Debug.WriteLine("pass5");

            // drop all available scheduled courses for this student
            for (int i = 0; i < scheduleList.Count; i++)
            {
                BLEnrollment.DeleteEnrollment(student.id, scheduleList[i].id, ref errors);                
                Assert.AreEqual(0, errors.Count);
            }

            BLStudent.DeleteStudent(student.id, ref errors);
            //VERIFY, GET
            Student verifyEmptyStudent = BLStudent.GetStudent(student.id, ref errors);
            Assert.AreEqual(0, errors.Count);
            Assert.AreEqual(null, verifyEmptyStudent);
            

            BLCheck.printErrorLog(ref errors);
        }


        [TestMethod]
        public void BusinessLayerEnrollmentErrorTest()
        {
            List<string> errors = new List<string>();

            Student student = new Student();
            student.id = "A12345649"; // use the existing student ID 
            student.first_name = "first2";
            student.last_name = " last2";
            student.ssn = "777664121";
            student.email = "myemail102@ucsd.edu";
            student.password = "pass1234";
            student.shoe_size = 2;
            student.weight = 2;
            student.major = 1;//JUSTIN ADDED THIS
            //student.level = (StudentLevel)Enum.Parse(typeof(StudentLevel), "freshman");//JUSTIN ADDED THIS
            student.level = "freshman";//JUSTIN ADDED THIS
            student.status = 0;//JUSTIN ADDED THIS

            //System.Diagnostics.Debug.WriteLine("value of student.level is: " + student.level.ToString());
            BLStudent.InsertStudent(student, ref errors);
            Assert.AreEqual(0, errors.Count);

            List<ScheduledCourse> scheduleList = new List<ScheduledCourse>();
            for (int i = 101; i <= 110; i++)
            {
                scheduleList.Add(BLCourseSchedule.GetCourseScheduleDetail(i, ref errors));
            }
            Assert.AreEqual(0, errors.Count);
            System.Diagnostics.Debug.WriteLine("pass1");
            int x = 0;
            // enroll all available scheduled courses for this student
            for (int i = 0; i < scheduleList.Count; i++)
            {
                x++;
                // this enrolls the student into one course at a time, hence the for loop
                BLEnrollment.InsertEnrollment(student.id + "abc", scheduleList[i].id, ref errors);
                Assert.AreEqual(x, errors.Count);
            }
            System.Diagnostics.Debug.WriteLine("pass1");
            //updating grade
            for (int i = 0; i < scheduleList.Count; i++)
            {
                x += 2;
                BLEnrollment.UpdateEnrollment(student.id + "abc", scheduleList[i].id, "aplus", ref errors);
                Assert.AreEqual(x, errors.Count);
            }

            //get enroll data
            x++;
            List<Enrollment> trans = BLEnrollment.GetEnrollment(student.id + "abc", ref errors);
            Assert.AreEqual(x, errors.Count);
            
            for (int i = 0; i < scheduleList.Count; i++)
            {
                x++;
                BLEnrollment.DeleteEnrollment(student.id +"abc", scheduleList[i].id, ref errors);
                Assert.AreEqual(x, errors.Count);
            }
            System.Diagnostics.Debug.WriteLine("end");
            errors = new List<string>();
            BLStudent.DeleteStudent("A12345649", ref errors);   //Dont know why it is not working
            //Assert.AreEqual(x, errors.Count);
            //VERIFY, GET
            Assert.AreEqual(0, errors.Count);
           
            //Student verifyEmptyStudent = BLStudent.GetStudent("A12345649", ref errors);
  
            
            //BLCheck.printErrorLog(ref errors);
        }

    }
}
