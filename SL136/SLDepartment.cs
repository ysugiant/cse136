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

    public void DeleteDepartment(int id, ref List<string> errors)
    {
      BLDepartment.DeleteDepartment(id, ref errors);
    }

    public Department GetDepartmentDetail(int id, ref List<string> errors)
    {
      return BLDepartment.GetDepartmentDetail(id, ref errors);
    }

    public List<Department> GetDepartmentList(ref List<string> errors)
    {
        return BLDepartment.GetDepartmentList(ref errors);
    }

    public void UpdateDepartment(Department dept, ref List<string> errors)
    {
        BLDepartment.UpdateDepartment(dept, ref errors);
    }
  }
}
