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
    // NOTE: You can use the "Rename" command on the "Refactor" menu to change the interface name "ISLCourse" in both code and config file together.
    [ServiceContract]
    public interface ISLMajor
    {
        [OperationContract]
        void InsertMajor(Major major, ref List<string> errors);

        [OperationContract]
        void UpdateMajor(Major major, ref List<string> errors);

        [OperationContract]
        void DeleteMajor(int id, ref List<string> errors);

        [OperationContract]
        Major GetMajorDetail(int id, ref List<string> errors);

        [OperationContract]
        List<Major> GetMajorList(ref List<string> errors);
    }
}
