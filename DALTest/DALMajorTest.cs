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
    public class DALMajorTest
    {
        public DALMajorTest()
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
        public void MajorTest()
        {
            List<string> errors = new List<string>(); //ERRORS list
            
            //INSERT
            Major major = new Major();
            major.majorName = "Test Major";
            major.deptId = 1;

            int ID;
            DALMajor.InsertMajor(major, ref errors, out ID);
            major.id = ID;

            //check for errors
            Assert.AreEqual(0, errors.Count);

            //VERIFY, GET
            Major verifyMajor = DALMajor.GetMajorDetail(ID, ref errors);
            
            //check for errors
            Assert.AreEqual(0, errors.Count);

            Assert.AreEqual(major.id, verifyMajor.id);
            Assert.AreEqual(major.majorName, verifyMajor.majorName);
            Assert.AreEqual(major.deptId, verifyMajor.deptId);

            //check for errors
            Assert.AreEqual(0, errors.Count);

            //DALMajor.GetMajorDetail(ID, ref errors);

            //UPDATE
            Major major2 = new Major();

            major2.id = major.id;
            major2.majorName = "Test2 Major";
            major2.deptId = 1;

            DALMajor.UpdateMajor(major2, ref errors);

            //VERIFY, GET
            verifyMajor = DALMajor.GetMajorDetail(major2.id, ref errors);

            //check for errors
            Assert.AreEqual(0, errors.Count);

            Assert.AreEqual(major2.id, verifyMajor.id);
            Assert.AreEqual(major2.majorName,verifyMajor.majorName);
            Assert.AreEqual(major2.deptId, verifyMajor.deptId);

            //check for errors
            Assert.AreEqual(0, errors.Count);

            //GET LIST (NEED TO MODIFY?)
            List<Major> majorList = DALMajor.GetMajorList(ref errors);
            Assert.AreEqual(0, errors.Count);

            //DELETE
            DALMajor.DeleteMajor(major2.id, ref errors);
      
            //VERIFY, GET
            Major verifyEmptyMajor = DALMajor.GetMajorDetail(major2.id, ref errors);
            Assert.AreEqual(0, errors.Count);
            Assert.AreEqual(null, verifyEmptyMajor);
        }
    }
}
