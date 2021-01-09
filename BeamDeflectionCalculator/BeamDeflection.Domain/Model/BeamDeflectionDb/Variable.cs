using BeamDeflection.Basecore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeamDeflection.Domain.Model.BeamDeflectionDb
{
    public class Variable : BaseEntity
    {
        public string Name { get; set; }
        public string Display { get; set; }
        public double Value { get; set; }
        public int CalculationId { get; set; }
        public Calculation Calculation { get; set; }
        public int UnitId { get; set; }
        public Unit Unit { get; set; }
        public override string ToString()
        {
            return Name;
        }

    }
}
