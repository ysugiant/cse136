using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using POCO;
using BL;

namespace BLTest
{
  /// <summary>
  /// Summary description for UnitTest1
  /// </summary>
  [TestClass]
  public class BLStudentTest
  {
    public BLStudentTest()
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

    [TestMethod]
    public void BusinessLayerStudentTest() //InsertStudentErrorTest()
    {
      //######################################TESTING INSERTION ERRORS#################################
      List<string> errors = new List<string>();

      BLStudent.InsertStudent(null, ref errors);
      Assert.AreEqual(1, errors.Count);

      errors.Clear();

      Student student = new Student();
      student.id = "";// fail, student id, cannot be empty.
      student.ssn = "justinbogart";// fail, too long
      student.email = "blah@more!~...Blah@32";// fail, regex
      student.password = "someCrazyBullshitPasswordThatIsTooLong";// fail, too many characters
      student.first_name = null;// fail, cannot be null
      student.last_name = "";// fail, cannot be empty
      student.shoe_size = -20;// fail, cannot be non-positive
      student.weight = -135;// fail, cannot be non-positive
      student.level = (StudentLevel)Enum.Parse(typeof(StudentLevel), "freshman");
      student.status = 99;// fail, must be between 0-2
      student.major = -1;// fail, cannot be negative

      BLStudent.InsertStudent(student, ref errors);

      // 10 errors should have been logged.
      Assert.AreEqual(10, errors.Count);

      //########################################TESTING SELECTION ERRORS##############################
      errors.Clear();
      BLStudent.GetStudent(null, ref errors);
      Assert.AreEqual(1, errors.Count);

      //#######################################TESTING DELETION ERRORS###############################
      errors.Clear();
      BLStudent.DeleteStudent(null, ref errors);
      Assert.AreEqual(1, errors.Count);

      //#######################################TESTING BLSTUDENT FUNCTIONS############################
      errors.Clear();
      student = new Student();
      student.first_name = "first";
      student.last_name = " last";
      student.id = "A12345678";
      student.ssn = "555555555";
      student.email = "myemail15@ucsd.edu";
      student.password = "pass123456";
      student.shoe_size = 0;
      student.weight = 0;
      student.major = 1;
      //student.level = 0;
      student.level = new StudentLevel();
      student.level = (StudentLevel)Enum.Parse(typeof(StudentLevel), "senior");// fail, must be a legitimate student level
      student.status = 0;
      student.enrolled = new List<ScheduledCourse>();

      errors.Clear();
      BLStudent.InsertStudent(student, ref errors);
      Assert.AreEqual(0, errors.Count);

      Student verifyStudent = BLStudent.GetStudent(student.id, ref errors);

      Assert.AreEqual(0, errors.Count);
      Assert.AreEqual(student.first_name, verifyStudent.first_name);
      Assert.AreEqual(student.last_name, verifyStudent.last_name);
      Assert.AreEqual(student.id, verifyStudent.id);
      Assert.AreEqual(student.ssn, verifyStudent.ssn);
      Assert.AreEqual(student.email, verifyStudent.email);
      Assert.AreEqual(student.shoe_size, verifyStudent.shoe_size);
      Assert.AreEqual(student.weight, verifyStudent.weight);
      Assert.AreEqual(student.major, verifyStudent.major);
      Assert.AreEqual(student.level, verifyStudent.level);
      Assert.AreEqual(student.status, verifyStudent.status);

      BLStudent.DeleteStudent(student.id, ref errors);

      Student verifyEmptyStudent = BLStudent.GetStudent(student.id, ref errors);
      Assert.AreEqual(0, errors.Count);
      Assert.AreEqual(null, verifyEmptyStudent);
    }
  }
}
