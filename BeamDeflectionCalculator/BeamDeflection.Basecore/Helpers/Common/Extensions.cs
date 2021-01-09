using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeamDeflection.Basecore.Helpers.Common
{
    public static class Extensions
    {

        public static Exception GetOriginalException(this Exception exc)
        {
            if (exc.InnerException != null)
            {
                exc.GetOriginalException();
            }
            return exc;
        }
    }
}
