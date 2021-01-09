using BeamDeflection.Basecore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeamDeflection.Domain.Model.Intersections
{
    public class UserRoles : BaseModel
    {
        public int UserId { get; set; }
        public int RoleId { get; set; }
    }
}
