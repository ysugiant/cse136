﻿using System;
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
    public class DALScheduleTimeTest
    {
        public DALScheduleTimeTest()
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
        public void ScheduleTimeTest()
        {
            string time = "23.00-24.00";

            List<string> errors = new List<string>();
            DALScheduleTime.InsertScheduleTime(time, ref errors);

            Assert.AreEqual(0, errors.Count);
            Dictionary<string, string> listtime = DALScheduleTime.GetScheduleTimeList(ref errors);

            System.Diagnostics.Debug.WriteLine(listtime.Count);

            Assert.AreEqual(listtime.ContainsValue(time), true);
            Assert.AreEqual(0, errors.Count);


            DALScheduleTime.DeleteScheduleTime(Convert.ToInt32(listtime.FirstOrDefault(x => x.Value.Contains(time)).Key), ref errors);

        //GET TEST
            time = "23.00-24.00";

            DALScheduleTime.InsertScheduleTime(time, ref errors);

            Assert.AreEqual(0, errors.Count);
            listtime = DALScheduleTime.GetScheduleTimeList(ref errors);

            System.Diagnostics.Debug.WriteLine(listtime.Count);

            Assert.AreEqual(listtime.ContainsValue(time), true);
            Assert.AreEqual(0, errors.Count);


            DALScheduleTime.DeleteScheduleTime(Convert.ToInt32(listtime.FirstOrDefault(x => x.Value.Contains(time)).Key), ref errors);

        //DELETE TEST
            time = "23.00-24.00";

            DALScheduleTime.InsertScheduleTime(time, ref errors);

            Assert.AreEqual(0, errors.Count);
            listtime = DALScheduleTime.GetScheduleTimeList(ref errors);

            System.Diagnostics.Debug.WriteLine(listtime.Count);

            Assert.AreEqual(listtime.ContainsValue(time), true);
            Assert.AreEqual(0, errors.Count);

            DALScheduleTime.DeleteScheduleTime(Convert.ToInt32(listtime.FirstOrDefault(x => x.Value.Contains(time)).Key), ref errors);
            Assert.AreEqual(0, errors.Count);

            listtime = DALScheduleTime.GetScheduleTimeList(ref errors);

            Assert.AreEqual(listtime.ContainsValue(time), false);
            Assert.AreEqual(0, errors.Count);
        }
    }
}