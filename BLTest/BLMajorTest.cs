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
        List<string> errors = new List<string>(); //ERRORS list

        Major major = new Major();
        major.majorName = "Test Major";
        major.deptId = 1;

        int ID;
        BLMajor.InsertMajor(major, ref errors, out ID);
        major.id = ID;

        //check for errors
        Assert.AreEqual(0, errors.Count);

        //VERIFY, GET
        Major verifyMajor = BLMajor.GetMajorDetail(ID, ref errors);

        //check for errors
        Assert.AreEqual(0, errors.Count);

        Assert.AreEqual(major.id, verifyMajor.id);
        Assert.AreEqual(major.majorName, verifyMajor.majorName);
        Assert.AreEqual(major.deptId, verifyMajor.deptId);

        //check for errors
        Assert.AreEqual(0, errors.Count);

        //BLMajor.GetMajorDetail(ID, ref errors);

        //UPDATE
        Major major2 = new Major();

        major2.id = major.id;
        major2.majorName = "Test2 Major";
        major2.deptId = 1;

        BLMajor.UpdateMajor(major2, ref errors);

        //VERIFY, GET
        verifyMajor = BLMajor.GetMajorDetail(major2.id, ref errors);

        //check for errors
        Assert.AreEqual(0, errors.Count);

        Assert.AreEqual(major2.id, verifyMajor.id);
        Assert.AreEqual(major2.majorName, verifyMajor.majorName);
        Assert.AreEqual(major2.deptId, verifyMajor.deptId);

        //check for errors
        Assert.AreEqual(0, errors.Count);

        //GET LIST (NEED TO MODIFY?)
        List<Tuple<string, string>> majorList = BLMajor.GetMajorList(ref errors);
        Assert.AreEqual(0, errors.Count);

        //DELETE
        BLMajor.DeleteMajor(major2.id, ref errors);

        //VERIFY, GET
        Major verifyEmptyMajor = BLMajor.GetMajorDetail(major2.id, ref errors);
        Assert.AreEqual(0, errors.Count);
        Assert.AreEqual(null, verifyEmptyMajor);

        BLCheck.printErrorLog(ref errors);
    }

    [TestMethod]
    public void BusinessLayerMajorErrorTest()
    {
        List<string> errors = new List<string>(); //ERRORS list

        //MALFORMED POCOS
        //errors.Add("Major name cannot be empty");
        Major majorEmpty = new Major();
        majorEmpty.majorName = "";
        majorEmpty.deptId = 1;

        //errors.Add("Major name cannot be more than 50");
        Major major50 = new Major();
        //60 characters
        major50.majorName = "123456789012345678901234567890123456789012345678901234567890"; 
        major50.deptId = -9;

        //errors.Add("Major name cannot be null");
        Major majorNull = new Major();
        majorNull.majorName = null;
        majorNull.deptId = 1;

        //INSERT 1
        int ID1;
        BLMajor.InsertMajor(majorEmpty, ref errors, out ID1);
        majorEmpty.id = ID1;
        Assert.AreEqual(1, errors.Count);

        //INSERT 2
        int ID2;
        BLMajor.InsertMajor(major50, ref errors, out ID2);
        major50.id = ID2;
        Assert.AreEqual(3, errors.Count);
        
        //VERIFY, GET 
        //Get with a negative value for major id
        Major verifyEmptyMajorEmpty = BLMajor.GetMajorDetail(majorEmpty.id, ref errors);
        Assert.AreEqual(4, errors.Count);
        Assert.AreEqual(null, verifyEmptyMajorEmpty);

        //DELETE
        //Delete with a negative value for major id
        BLMajor.DeleteMajor(major50.id, ref errors);
        Assert.AreEqual(5, errors.Count);
        
        //UPDATE
        BLMajor.UpdateMajor(majorNull, ref errors);
        Assert.AreEqual(6, errors.Count);

        BLCheck.printErrorLog(ref errors);
    }
  }
}
