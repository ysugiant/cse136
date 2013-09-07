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
    public class DALScheduleDayTest
    {
        public DALScheduleDayTest()
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
        public void ScheduleDayTest()
        {
            string day = "TestDay";

            List<string> errors = new List<string>();
            DALScheduleDay.InsertScheduleDay(day, ref errors);

            Assert.AreEqual(0, errors.Count);
            Dictionary<string,string> listday = DALScheduleDay.GetScheduleDayList(ref errors);

            System.Diagnostics.Debug.WriteLine(listday.Count);

            Assert.AreEqual(listday.ContainsValue(day), true);
            Assert.AreEqual(0, errors.Count);


            DALScheduleDay.DeleteScheduleDay(Convert.ToInt32(listday.FirstOrDefault(x => x.Value.Contains(day)).Key), ref errors);

            //TEST
            day = "TestDay";

            DALScheduleDay.InsertScheduleDay(day, ref errors);

            Assert.AreEqual(0, errors.Count);
            listday = DALScheduleDay.GetScheduleDayList(ref errors);

            System.Diagnostics.Debug.WriteLine(listday.Count);

            Assert.AreEqual(listday.ContainsValue(day), true);
            Assert.AreEqual(0, errors.Count);


            DALScheduleDay.DeleteScheduleDay(Convert.ToInt32(listday.FirstOrDefault(x => x.Value.Contains(day)).Key), ref errors);

        //DELETE TEST
            day = "TestDay";

            errors = new List<string>();
            DALScheduleDay.InsertScheduleDay(day, ref errors);

            Assert.AreEqual(0, errors.Count);
            listday = DALScheduleDay.GetScheduleDayList(ref errors);

            System.Diagnostics.Debug.WriteLine(listday.Count);

            Assert.AreEqual(listday.ContainsValue(day), true);
            Assert.AreEqual(0, errors.Count);


            DALScheduleDay.DeleteScheduleDay(Convert.ToInt32(listday.FirstOrDefault(x => x.Value.Contains(day)).Key), ref errors);
            Assert.AreEqual(0, errors.Count);

            listday = DALScheduleDay.GetScheduleDayList(ref errors);

            Assert.AreEqual(listday.ContainsValue(day), false);
            Assert.AreEqual(0, errors.Count);

        }
    }
}