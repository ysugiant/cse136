using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using POCO; // this is required
using BL; // this is required

namespace SL136
{
  // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "IService1" in both code and config file together.
  [ServiceContract]
  public interface ISLEnrollment
  {

    [OperationContract]
    List<Enrollment> GetEnrollmentList(string student_id, ref List<string> errors);

    [OperationContract]
    void InsertEnrollment(string student_id, int schedule_id, ref List<string> errors);

    [OperationContract]
    void DeleteEnrollment(string student_id, int schedule_id, ref List<string> errors);

    [OperationContract]
    void UpdateEnrollment(string student_id, int schedule_id, string grade, ref List<string> errors);

  }
}
