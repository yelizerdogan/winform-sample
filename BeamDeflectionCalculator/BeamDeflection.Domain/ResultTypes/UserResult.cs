using BeamDeflection.Basecore.Model.Enums;
using BeamDeflection.Basecore.Model.ResultTypes;
using BeamDeflection.Domain.Constants;
using BeamDeflection.Domain.Model.BeamDeflectionDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeamDeflection.Domain.ResultTypes
{
    public class UserResult :BusinessResult<ApplicationUser>
    {
        public UserResult(UserResultType userState, ApplicationUser u, string msg, BusinessResultType state)
          : base(u, msg, state)
        {
            UserState = userState;
        }

        public UserResultType UserState { get; set; }
    }
}
