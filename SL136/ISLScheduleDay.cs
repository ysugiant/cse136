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
  public interface ISLScheduleDay
  {

    [OperationContract]
    Dictionary<string, string> GetScheduleDayList(ref List<string> errors);

    [OperationContract]
    void InsertScheduleDay(string day, ref List<string> errors);

    [OperationContract]
    void DeleteScheduleDay(string id, ref List<string> errors);

  }
}
