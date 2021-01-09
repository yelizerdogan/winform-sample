using BeamDeflection.Basecore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeamDeflection.Domain.Model.BeamDeflectionDb
{
    public class Role : BaseEntity
    {
        public string Name { get; set; }
        public ICollection<ApplicationUser> Users { get; set; }
        public override string ToString()
        {
            return Name;
        }
    }
}
