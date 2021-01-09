using BeamDeflection.Basecore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeamDeflection.Domain.Model.BeamDeflectionDb
{
    public class Unit :BaseEntity
    {
        public string Name { get; set; }
        public string Display { get; set; }
        public ICollection<Variable> Variables { get; set; }
        public ICollection<Calculation> Calculations { get; set; }
        public override string ToString()
        {
            return Name;
        }
    }
}
