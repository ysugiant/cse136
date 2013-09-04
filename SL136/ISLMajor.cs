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
    class ISLMajor
    {
        [OperationContract]
         List<Tuple<string, string>> GetMajorList(ref List<string> errors);

        [OperationContract]
        void InsertMajor(Major major, ref List<string> errors, out int ID);

        [OperationContract]
       void UpdateMajor(Major major, ref List<string> errors);

        [OperationContract]
        void DeleteMajor(int id, ref List<string> errors);

        [OperationContract]
        Major GetMajorDetail(int id, ref List<string> errors);

    }
}
