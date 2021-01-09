using BeamDeflection.Domain.Constants;
using BeamDeflection.Domain.Model.BeamDeflectionDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeamDeflection.Datacore.Context.Mapping
{
    public class CalculationMap :BaseEntityMap<Calculation>
    {
        public CalculationMap()
        {
            ToTable(DbConstants.Calculation.Name, DbConstants.Calculation.Schema);
            Property(x=>x.Result)
                .HasColumnType("float");
            HasRequired(x => x.Load)
                .WithMany(x => x.Calculations)
                .HasForeignKey(x => x.LoadId)
                .WillCascadeOnDelete(true);
            HasRequired(x=>x.AppUser)
                .WithMany(x=>x.Calculations)
                .HasForeignKey(x=>x.UserId)
                .WillCascadeOnDelete(true);
            HasRequired(x => x.Unit)
                .WithMany(x => x.Calculations)
                .HasForeignKey(x => x.UnitId)
                .WillCascadeOnDelete(false);
        }
    }
}
