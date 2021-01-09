using BeamDeflection.Basecore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeamDeflection.Domain.Model.BeamDeflectionDb
{
    public class Load :BaseEntity
    {
        public string Name { get; set; }
        public int BeamId { get; set; }
        public Beam Beam { get; set; }
        public ICollection<Calculation> Calculations { get; set; }
        public override string ToString()
        {
            return Name;
        }

    }
}
