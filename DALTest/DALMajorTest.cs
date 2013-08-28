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
            //NOT IMPLEMENTED
            List<string> errors = new List<string>();
            int ID;
            Major major = new Major();
            major.majorName = "Computer Science";
            major.deptId = 1;


            DALMajor.InsertMajor(major.majorName,  major.deptId, ref errors, out ID);

            Assert.AreEqual(0, errors.Count);

            Major verifyMajor = new Major();
            verifyMajor = DALMajor.GetMajorDetail(ID, ref errors);
            //Assert.AreEqual(student.ToString(),verifyStudent.ToString());
            Assert.AreEqual(0, errors.Count);
            Assert.AreEqual(major.majorName, verifyMajor.majorName);
            Assert.AreEqual(major.deptId, verifyMajor.deptId);
            DALMajor.GetMajorDetail(ID, ref errors);


            Major major2 = new Major();

            major2.majorName = "Math";
            major2.deptId = 120;

            DALMajor.UpdateMajor(ID,major2.majorName, major2.deptId, ref errors);

            verifyMajor = DALMajor.GetMajorDetail(ID, ref errors);
            Assert.AreEqual(0, errors.Count);
            //   Assert.AreEqual(course2.id, verifyCourse.id);
            Assert.AreEqual(major2.majorName,verifyMajor.majorName);
            Assert.AreEqual(major2.deptId, verifyMajor.deptId);
            



            // need to modify!!!!!


            List<Tuple<string, string>> majorList = DALMajor.GetMajorList(ref errors);
            Assert.AreEqual(0, errors.Count);

          

            DALMajor.DeleteMajor(ID, ref errors);
      
            Major verifyEmptyMajor = DALMajor.GetMajorDetail(ID, ref errors);
            Assert.AreEqual(0, errors.Count);
            Assert.AreEqual(null, verifyEmptyMajor);



        }

    }
}
