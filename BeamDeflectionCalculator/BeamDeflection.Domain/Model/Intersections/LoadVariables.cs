using BeamDeflection.Basecore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeamDeflection.Domain.Model.Intersections
{
    public class LoadVariables :BaseModel
    {
        public int LoadId { get; set; }
        public int VariableId { get; set; }
    }
}
