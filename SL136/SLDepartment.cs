using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using POCO;
using BL;

namespace SL136
{
  // NOTE: You can use the "Rename" command on the "Refactor" menu to change the class name "SLStudent" in both code and config file together.
  public class SLDepartment : ISLDepartment
  {
    public void InsertDepartment(Department dept, ref List<string> errors)
    {
      BLDepartment.InsertDepartment(dept, ref errors);
    }

    public void DeleteDepartment(string name, ref List<string> errors)
    {
      BLDepartment.DeleteDepartment(name, ref errors);
    }

    public Department GetDepartmentDetail(string name, ref List<string> errors)
    {
      return BLDepartment.GetDepartmentDetail(name, ref errors);
    }

    public void UpdateDepartment(Department dept, ref List<string> errors)
    {
        BLDepartment.UpdateDepartment(dept, ref errors);
    }
  }
}
