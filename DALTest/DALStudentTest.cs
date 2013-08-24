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
  public class DALStudentTest
  {
    public DALStudentTest()
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
    public void InsertStudentTest()
    {
      Student student = new Student();
      student.first_name = "first";
      student.last_name = " last";
      student.id = Guid.NewGuid().ToString().Substring(0, 20);
      student.ssn = "8889912";
      student.email = "myemail@ucsd.edu";
      student.password = "pass1234";
      student.shoe_size = 0;
      student.weight = 0;
      student.major = 1;//JUSTIN ADDED THIS
      student.level = StudentLevel.freshman;//JUSTIN ADDED THIS
      student.status = 0;//JUSTIN ADDED THIS
      student.enrolled = new List<ScheduleCourse>();//JUSTIN ADDED THIS

      List<string> errors = new List<string>();
      DALStudent.InsertStudent(student, ref errors);

      Assert.AreEqual(0, errors.Count);

      Student verifyStudent = DALStudent.GetStudentDetail(student.id, ref errors);
      //Assert.AreEqual(student.ToString(),verifyStudent.ToString());//JUSTIN ADDED THIS
      Assert.AreEqual(0, errors.Count);
      Assert.AreEqual(student.first_name, verifyStudent.first_name);
      Assert.AreEqual(student.last_name, verifyStudent.last_name);
      Assert.AreEqual(student.id, verifyStudent.id);
      Assert.AreEqual(student.ssn, verifyStudent.ssn);
      Assert.AreEqual(student.email, verifyStudent.email);
      Assert.AreEqual(student.password, verifyStudent.password);
      Assert.AreEqual(student.shoe_size, verifyStudent.shoe_size);
      Assert.AreEqual(student.weight, verifyStudent.weight);
      Assert.AreEqual(student.major, verifyStudent.major);//JUSTIN ADDED THIS
      Assert.AreEqual(student.level, verifyStudent.level);//JUSTIN ADDED THIS
      Assert.AreEqual(student.status, verifyStudent.status);//JUSTIN ADDED THIS

      //SHOULDN'T THIS BE THE END OF InsertStudentTest() ??????????

      Student student2 = new Student();
      student2.id = student.id; // use the existing student ID 
      System.Diagnostics.Debug.WriteLine("value of student2's id is: " + student2.id);//JUSTIN ADDED THIS
      student2.first_name = "first2";
      student2.last_name = " last2";
      student2.ssn = "777664321";
      student2.email = "myemail2@ucsd.edu";
      student2.password = "pass1234";
      student2.shoe_size = 2;
      student2.weight = 2;
      student2.major = 1;//JUSTIN ADDED THIS
      student2.level = StudentLevel.senior;//JUSTIN ADDED THIS
      student2.status = 0;//JUSTIN ADDED THIS

      //System.Diagnostics.Debug.WriteLine("value of student.level is: " + student.level.ToString());
      DALStudent.UpdateStudent(student2, ref errors);

      verifyStudent = DALStudent.GetStudentDetail(student2.id, ref errors);
      Assert.AreEqual(0, errors.Count);
      Assert.AreEqual(student2.first_name, verifyStudent.first_name);
      Assert.AreEqual(student2.last_name, verifyStudent.last_name);
      Assert.AreEqual(student2.id, verifyStudent.id);
      Assert.AreEqual(student2.ssn, verifyStudent.ssn);
      Assert.AreEqual(student2.email, verifyStudent.email);
      Assert.AreEqual(student2.password, verifyStudent.password);
      Assert.AreEqual(student2.shoe_size, verifyStudent.shoe_size);
      Assert.AreEqual(student2.weight, verifyStudent.weight);
      Assert.AreEqual(student2.major, verifyStudent.major);//JUSTIN ADDED THIS
      Assert.AreEqual(student2.level, verifyStudent.level);//JUSTIN ADDED THIS
      Assert.AreEqual(student2.status, verifyStudent.status);//JUSTIN ADDED THIS

      List<ScheduleCourse> scheduleList = DALCourseSchedule.GetScheduleList("", "", ref errors);
      Assert.AreEqual(0, errors.Count);

      // enroll all available scheduled courses for this student
      for (int i = 0; i < scheduleList.Count; i++)
      {
        // this enrolls the student into one course at a time, hence the for loop
        DALStudent.EnrollSchedule(student.id, scheduleList[i].id, ref errors);
        Assert.AreEqual(0, errors.Count);
      }

      // drop all available scheduled courses for this student
      for (int i = 0; i < scheduleList.Count; i++)
      {
        DALStudent.DropEnrolledSchedule(student.id, scheduleList[i].id, ref errors);
        Assert.AreEqual(0, errors.Count);
      }

      DALStudent.DeleteStudent(student.id, ref errors);

      Student verifyEmptyStudent = DALStudent.GetStudentDetail(student.id, ref errors);
      Assert.AreEqual(0, errors.Count);
      Assert.AreEqual(null, verifyEmptyStudent);

    }
  }
}
