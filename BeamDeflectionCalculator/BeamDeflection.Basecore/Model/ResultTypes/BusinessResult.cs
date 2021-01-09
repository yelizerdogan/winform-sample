using BeamDeflection.Basecore.Model.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeamDeflection.Basecore.Model.ResultTypes
{
    public class BusinessResult<T> : IBusinessResult<T>
    {


        public BusinessResult(T rslt, string msg = "", BusinessResultType type = BusinessResultType.Success)
        {
            Result = rslt;
            Message = msg;
            State = type;
        }

        public T Result { get; set; }

        public string Message { get; set; }
        public BusinessResultType State { get; set; }
    }
}
