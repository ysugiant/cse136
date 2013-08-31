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
    public class BLScheduleDayTest
    {
        public BLScheduleDayTest()
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
        public void BusinessLayerScheduleDayTest()
        {
            string day = "TestDay";

            List<string> errors = new List<string>();
            BLScheduleDay.InsertScheduleDay(day, ref errors);

            Assert.AreEqual(0, errors.Count);
            List<string> listday = BLScheduleDay.GetScheduleDayList(ref errors);

            System.Diagnostics.Debug.WriteLine(listday.Count);

            bool x = false;
            for (int i = 0; i < listday.Count; i++)
            {
                System.Diagnostics.Debug.WriteLine(listday[i]);

                if (listday[i] == day)
                    x = true;
            }
            Assert.AreEqual(x, true);
            Assert.AreEqual(0, errors.Count);


            BLScheduleDay.DeleteScheduleDay(day, ref errors);

            //TEST
            day = "TestDay";

            BLScheduleDay.InsertScheduleDay(day, ref errors);

            Assert.AreEqual(0, errors.Count);
            listday = BLScheduleDay.GetScheduleDayList(ref errors);

            System.Diagnostics.Debug.WriteLine(listday.Count);

            x = false;
            for (int i = 0; i < listday.Count; i++)
            {
                System.Diagnostics.Debug.WriteLine(listday[i]);

                if (listday[i] == day)
                    x = true;
            }
            Assert.AreEqual(x, true);
            Assert.AreEqual(0, errors.Count);


            BLScheduleDay.DeleteScheduleDay(day, ref errors);

            //DELETE TEST
            day = "TestDay";

            errors = new List<string>();
            BLScheduleDay.InsertScheduleDay(day, ref errors);

            Assert.AreEqual(0, errors.Count);
            listday = BLScheduleDay.GetScheduleDayList(ref errors);

            System.Diagnostics.Debug.WriteLine(listday.Count);

            x = false;
            for (int i = 0; i < listday.Count; i++)
            {
                System.Diagnostics.Debug.WriteLine(listday[i]);

                if (listday[i] == day)
                    x = true;
            }
            Assert.AreEqual(x, true);
            Assert.AreEqual(0, errors.Count);


            BLScheduleDay.DeleteScheduleDay(day, ref errors);
            Assert.AreEqual(0, errors.Count);

            listday = BLScheduleDay.GetScheduleDayList(ref errors);

            x = false;
            for (int i = 0; i < listday.Count; i++)
            {
                System.Diagnostics.Debug.WriteLine(listday[i]);

                if (listday[i] == day)
                    x = true;
            }
            Assert.AreEqual(x, false);
            Assert.AreEqual(0, errors.Count);

        }

        [TestMethod]
        public void BusinessLayerScheduleDayErrorTest()
        {
            string day = "TestDay123456789123456789123456789123456789123456789123456789";

            List<string> errors = new List<string>();

            BLScheduleDay.InsertScheduleDay(day, ref errors);
            Assert.AreEqual(1, errors.Count);

            //get doesnt have error checking

            BLScheduleDay.DeleteScheduleDay(day, ref errors);
            Assert.AreEqual(2, errors.Count);

        }
    }
}