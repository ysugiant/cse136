﻿using System;
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
  public class BLMajorTest
  {
    public BLMajorTest()
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
    public void BusinessLayerMajorTest()
    {
        //INSERT        InsertMajor(string majorName, int deptID, ref List<string> errors)
        //checkMajorName
        //CheckDeptID

        //UPDATE        UpdateMajor(int majorID, string majorName, int deptID, ref List<string> errors)
        //checkMajorName
        //CheckMajorID
        //CheckDeptID

        //DELETE        DeleteMajor(int id, ref List<string> errors)
        //CheckMajorID

        //GET           GetMajorDetail(int id, ref List<string> errors)
        //CheckMajorID

        //GET LIST      GetMajorList(ref List<string> errors)
        
        
        
        /*
      List<string> errors = new List<string>();

      BLStudent.InsertStudent(null, ref errors);
      Assert.AreEqual(1, errors.Count);

      errors = new List<string>();

      Student student = new Student();
      student.id = "";
      BLStudent.InsertStudent(student, ref errors);
      Assert.AreEqual(1, errors.Count); */
    }

    [TestMethod]
    public void BusinessLayerMajorErrorTest()
    {

    }
  }
}
