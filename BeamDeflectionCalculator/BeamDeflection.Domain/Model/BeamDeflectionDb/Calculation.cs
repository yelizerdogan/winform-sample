using BeamDeflection.Basecore.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeamDeflection.Domain.Model.BeamDeflectionDb
{
    public class Calculation : BaseEntity
    {
        public double Result { get; set; }
        public int LoadId { get; set; }
        public int UserId { get; set; }
        public Load Load { get; set; }
        public int UnitId { get; set; }
        public Unit Unit { get; set; }
        public ApplicationUser AppUser { get; set; }
        public ICollection<Variable> Variables { get; set; }
        public override string ToString()
        {
            return Result.ToString();
        }

    }
}
