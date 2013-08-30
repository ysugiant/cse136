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
    public void InsertStudentErrorTest()
    {
      List<string> errors = new List<string>();

      BLStudent.InsertStudent(null, ref errors);
      Assert.AreEqual(1, errors.Count);

      errors = new List<string>();

      Student student = new Student();
      student.id = "";
      BLStudent.InsertStudent(student, ref errors);
      Assert.AreEqual(1, errors.Count);
    }

    [TestMethod]
    public void GetStudentErrorTest()
    {
      List<string> errors = new List<string>();

      BLStudent.GetStudent(null, ref errors);
      Assert.AreEqual(1, errors.Count);
    }

    [TestMethod]
    public void DeleteStudentErrorTest()
    {
      List<string> errors = new List<string>();

      BLStudent.DeleteStudent(null, ref errors);
      Assert.AreEqual(1, errors.Count);
    }

    [TestMethod]
    public void StudentInsertAndSelectTest()
    {
      Student student = new Student();
      student.first_name = "first";
      student.last_name = " last";
      student.id = Guid.NewGuid().ToString().Substring(0, 20);
      student.ssn = "555555555";
      student.email = "myemail15@ucsd.edu";
      student.password = "pass123456";
      student.shoe_size = 0;
      student.weight = 0;
      student.major = 1;
      student.level = 0;
      student.status = 0;
      student.enrolled = new List<ScheduledCourse>();

      List<string> errors = new List<string>();
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

      //List<ScheduledCourse> scheduleList = BLSchedule.GetScheduleList("", "", ref errors); // This was the original code.
      //List<ScheduledCourse> scheduleList = BLCourseSchedule.GetScheduleList(2011, "Fall", ref errors);//JUSTIN ADDED THIS FOR DUBUG PURPOSES
      //Assert.AreEqual(0, errors.Count);

      // enroll all available scheduled courses for this student
      /*for (int i = 0; i < scheduleList.Count; i++)
      {
        student.enrolled.Add(scheduleList[i]);// JUSTIN : for testing purposes. Will compare this with the List<ScheduledCourse>.
        //System.Diagnostics.Debug.WriteLine("Added a course to student course schedule: " + student.enrolled[i].course.title);//JUSTIN ADDED THIS
        
        BLStudent.EnrollSchedule(student.id, scheduleList[i].id, ref errors);
        //System.Diagnostics.Debug.WriteLine("Added a course to scheduleList: " + scheduleList[i].course.title);//JUSTIN ADDED THIS
        Assert.AreEqual(0, errors.Count);
      }

      // JUSTIN : Extra test to ensure that ALL the courses from the selected course schedule were added, verifies by count.
      System.Diagnostics.Debug.WriteLine("scheduleList size: " + scheduleList.Count + "\nStudent schedule size: " + student.enrolled.Count);//JUSTIN ADDED THIS
      Assert.AreEqual(scheduleList.Count, student.enrolled.Count);

      // drop all available scheduled courses for this student
      for (int i = 0; i < scheduleList.Count; i++)
      {
        BLStudent.DropEnrolledSchedule(student.id, scheduleList[i].id, ref errors);
        // This is not an accurate test because it doesn't verify that the student's enrollment schedule is empty.
        Assert.AreEqual(0, errors.Count);
        student.enrolled.Remove(scheduleList[i]);// JUSTIN : to use in the following assertion.
      }
      Assert.AreEqual(0, student.enrolled.Count);// JUSTIN : This makes sure that the student's enroll Sched is empty.

      /* JUSTIN : now the student object is up-to-date, including their course schedule.
       * NOTE: I think we should always keep the object updated, through every method acting upon it. Yeah? No?
       * */
      BLStudent.DeleteStudent(student.id, ref errors);

      Student verifyEmptyStudent = BLStudent.GetStudent(student.id, ref errors);
      Assert.AreEqual(0, errors.Count);
      Assert.AreEqual(null, verifyEmptyStudent);

    }

  }
}
