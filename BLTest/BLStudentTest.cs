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
    public void BusinessLayerStudentErrorTest()
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

        errors.Clear();
        Student student2 = new Student();
        student2.id = null;// fail, student id cannot be null
        student2.ssn = null;// fail, null
        student2.email = null;// fail, null
        student2.password = null;// fail, null
        student2.first_name = "";// fail, cannot be null
        student2.last_name = null;// fail, cannot be empty
        student2.shoe_size = 10;
        student2.weight = 135;
        student2.level = (StudentLevel)Enum.Parse(typeof(StudentLevel), "senior");
        student2.status = 0;
        student2.major = 1;
        BLStudent.InsertStudent(student2, ref errors);
        // 6 errors should have been logged.
        Assert.AreEqual(6, errors.Count);

        errors.Clear();
        Student student3 = new Student();
        student3.id = "11111111111111111111111";// fail, student id too long
        student3.ssn = "1234f6789";// fail, ssn cannot contain non-numeric characters
        student3.email = "lemmetalkwithjustinandjerhongandleenaandgrandmaandothers@gmail.com";// fail, too long
        student3.password = "";// fail, empty
        student3.first_name = "111111111111111111111111111111111111111111111111111";// fail, too long
        student3.last_name = "Coolio";
        student3.shoe_size = 10;
        student3.weight = 135;
        student3.level = (StudentLevel)Enum.Parse(typeof(StudentLevel), "senior");
        student3.status = 0;
        student3.major = 1;
        BLStudent.InsertStudent(student3, ref errors);
        // 5 errors should have been logged.
        BLCheck.printErrorLog(ref errors);
        Assert.AreEqual(5, errors.Count);

        errors.Clear();
        Student student4 = new Student();
        student4.id = "A12345689";
        student4.ssn = "456123589";
        student4.email = "";// fail, empty
        student4.password = "huyeahyeah";
        student4.first_name = "Bob";
        student4.last_name = "Coolio";
        student4.shoe_size = 10;
        student4.weight = 135;
        student4.level = (StudentLevel)Enum.Parse(typeof(StudentLevel), "senior");
        student4.status = 0;
        student4.major = 1;
        BLStudent.InsertStudent(student4, ref errors);
        // 1 error should have been logged.
        Assert.AreEqual(1, errors.Count);

        //########################################TESTING SELECTION ERRORS##############################
        errors.Clear();
        BLStudent.GetStudent(null, ref errors);
        Assert.AreEqual(1, errors.Count);

        //#######################################TESTING DELETION ERRORS###############################
        errors.Clear();
        BLStudent.DeleteStudent(null, ref errors);
        Assert.AreEqual(1, errors.Count);
    }

    [TestMethod]
    public void BusinessLayerStudentTest()
    {
      List<string> errors = new List<string>();

      //#######################################TESTING BLSTUDENT FUNCTIONS############################
      Student student = new Student();
      student.first_name = "first";
      student.last_name = " last";
      student.id = "A99999999";
      student.ssn = "555555555";
      student.email = "myemail15@ucsd.edu";
      student.password = "pass123456";
      student.shoe_size = 0;
      student.weight = 0;
      student.major = 1;
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
