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
    public class BLDepartmentTest
    {
        public BLDepartmentTest()
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
        public void BusinessLayerDepartmentTest()
        {
            Department dept = new Department();
            dept.deptName = "Test Department";
            dept.chairID = 1;

            List<string> errors = new List<string>();
            BLDepartment.InsertDepartment(dept, ref errors);

            Assert.AreEqual(0, errors.Count);
            Department verifyDept = BLDepartment.GetDepartmentDetail(dept.deptName, ref errors);
            dept.id = verifyDept.id;
            Assert.AreEqual(dept.ToString(), verifyDept.ToString());
            Assert.AreEqual(0, errors.Count);
            Assert.AreEqual(dept.ToString(), dept.ToString());

            BLDepartment.DeleteDepartment(dept.id, ref errors);

            //UPDATE TEST
            dept = new Department();
            dept.deptName = "Test Department";
            dept.chairID = 1;

            BLDepartment.InsertDepartment(dept, ref errors);

            Assert.AreEqual(0, errors.Count);

            //updating
            verifyDept = BLDepartment.GetDepartmentDetail(dept.deptName, ref errors);
            dept.id = verifyDept.id;
            dept.deptName = "Te Department";
            dept.chairID = 1;
            BLDepartment.UpdateDepartment(dept, ref errors);

            Assert.AreEqual(0, errors.Count);

            verifyDept = BLDepartment.GetDepartmentDetail(dept.deptName, ref errors);
            dept.id = verifyDept.id;
            Assert.AreEqual(dept.ToString(), verifyDept.ToString());
            Assert.AreEqual(0, errors.Count);
            Assert.AreEqual(dept.ToString(), dept.ToString());

            BLDepartment.DeleteDepartment(dept.id, ref errors);

            //GET TEST
            dept = new Department();
            dept.deptName = "Test Department";
            dept.chairID = 1;

            BLDepartment.InsertDepartment(dept, ref errors);

            Assert.AreEqual(0, errors.Count);
            verifyDept = BLDepartment.GetDepartmentDetail(dept.deptName, ref errors);
            dept.id = verifyDept.id;
            Assert.AreEqual(dept.ToString(), verifyDept.ToString());
            Assert.AreEqual(0, errors.Count);
            Assert.AreEqual(dept.ToString(), dept.ToString());

            BLDepartment.DeleteDepartment(dept.id, ref errors);

            //DELETE TEST
            dept = new Department();
            dept.deptName = "Test Department";
            dept.chairID = 1;

            BLDepartment.InsertDepartment(dept, ref errors);

            Assert.AreEqual(0, errors.Count);
            verifyDept = BLDepartment.GetDepartmentDetail(dept.deptName, ref errors);
            dept.id = verifyDept.id;
            Assert.AreEqual(dept.ToString(), verifyDept.ToString());
            Assert.AreEqual(0, errors.Count);
            Assert.AreEqual(dept.ToString(), dept.ToString());

            BLDepartment.DeleteDepartment(dept.id, ref errors);
            Assert.AreEqual(0, errors.Count);

            verifyDept = BLDepartment.GetDepartmentDetail(dept.deptName, ref errors);
            Assert.AreEqual(0, errors.Count);
            Assert.AreEqual(verifyDept, null);

        }

        [TestMethod]
        public void BusinessLayerDepartmentErrorTest()
        {
            Department dept = new Department();
            dept.deptName = "Test Department12345678901234567890123456789012345678901234567890";
            dept.chairID = -1;

            List<string> errors = new List<string>();
            BLDepartment.InsertDepartment(dept, ref errors);
            Assert.AreEqual(2, errors.Count);

            Department verifyDept = BLDepartment.GetDepartmentDetail(dept.deptName, ref errors);
            Assert.AreEqual(3, errors.Count);

            BLDepartment.UpdateDepartment(dept, ref errors);
            Assert.AreEqual(5, errors.Count);

            BLDepartment.DeleteDepartment(-125543, ref errors);
            Assert.AreEqual(6, errors.Count);
        }
    }
}
