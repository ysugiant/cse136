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
    public class DALStaffTest
    {
        public DALStaffTest()
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
        ///A test for InsertStaff
        ///</summary>
        [TestMethod]
        public void InsertStaffTest()
        {
            // Creating instructor to insert into database
            Staff instructor = new Instructor();
            //instructor.id = 123456; //Guid.NewGuid().ToString().Substring(0, 20);
            instructor.first_name = "first";
            instructor.last_name = " last";
            instructor.email = "myemail@ucsd.edu";
            instructor.password = "pass1234";
            instructor.dept = new Department();
            instructor.dept.id = 1;
            instructor.isInstructor = true;
            //System.Diagnostics.Debug.WriteLine("Instructor info: " + instructor.ToString());

            //========================================BEGIN STAFF INSERT TEST=============================================
            List<string> errors = new List<string>();

            int newInstrID;
            DALStaff.InsertStaff(instructor, ref errors, out newInstrID);
            Assert.AreEqual(0, errors.Count);
            instructor.id = newInstrID;
            System.Diagnostics.Debug.WriteLine("Retrieved instructor's id: " + newInstrID);
            System.Diagnostics.Debug.WriteLine("Inserted instructor's id: " + instructor.id);
            //=======================================BEGIN STAFF GET TEST=================================================
            
            Staff verifyInstructor = DALStaff.GetStaffDetail(newInstrID, ref errors);
            
            //Assert.AreEqual(chair.ToString(),verifychair.ToString());//JUSTIN ADDED THIS
            Assert.AreEqual(0, errors.Count);


            //System.Diagnostics.Debug.WriteLine("" + verifyInstructor.id + " " + instructor.id);
            Assert.AreEqual(instructor.id, verifyInstructor.id);
            Assert.AreEqual(instructor.first_name, verifyInstructor.first_name);
            Assert.AreEqual(instructor.last_name, verifyInstructor.last_name);
            Assert.AreEqual(instructor.email, verifyInstructor.email);
            Assert.AreEqual(instructor.password, verifyInstructor.password);
            Assert.AreEqual(instructor.dept.id, verifyInstructor.dept.id);// NOT SURE ABOUT THIS YET
            Assert.AreEqual(instructor.isInstructor, verifyInstructor.isInstructor);

            //===================================== BEGIN STAFF UPDATE CHECK ==========================================
            Staff staffMember2 = new Staff();
            staffMember2.id = instructor.id; // use the existing chair ID 
            staffMember2.first_name = "first2";
            staffMember2.last_name = " last2";
            staffMember2.email = "myemail2@ucsd.edu";
            staffMember2.password = "pass1234";
            staffMember2.dept = new Department();
            staffMember2.dept.id = 1;
            DALStaff.UpdateStaff(staffMember2, ref errors);

            verifyInstructor = DALStaff.GetStaffDetail(staffMember2.id, ref errors);
            Assert.AreEqual(0, errors.Count);
            Assert.AreEqual(staffMember2.id, verifyInstructor.id);
            Assert.AreEqual(staffMember2.first_name, verifyInstructor.first_name);
            Assert.AreEqual(staffMember2.last_name, verifyInstructor.last_name);
            Assert.AreEqual(staffMember2.email, verifyInstructor.email);
            Assert.AreEqual(staffMember2.password, verifyInstructor.password);
            Assert.AreEqual(staffMember2.dept.id, verifyInstructor.dept.id);// NOT SURE ABOUT THIS YET

            //List<ScheduleCourse> scheduleList = DALSchedule.GetScheduleList("", "", ref errors);
            Assert.AreEqual(0, errors.Count);

            /*
            // enroll all available scheduled courses for this chair
            for (int i = 0; i < scheduleList.Count; i++)
            {
                DALchair.EnrollSchedule(chair.id, scheduleList[i].id, ref errors);
                Assert.AreEqual(0, errors.Count);
            }

            // drop all available scheduled courses for this chair
            for (int i = 0; i < scheduleList.Count; i++)
            {
                DALchair.DropEnrolledSchedule(chair.id, scheduleList[i].id, ref errors);
                Assert.AreEqual(0, errors.Count);
            }*/
            //#########################################################################################################
            //=====================================BEGIN STAFF DELETE TEST=============================================
            DALStaff.DeleteStaff(instructor.id, ref errors);

            Staff verifyEmptyStaffMember = DALStaff.GetStaffDetail(instructor.id, ref errors);
            Assert.AreEqual(0, errors.Count);
            Assert.AreEqual(null, verifyEmptyStaffMember);

        }
    }
}
