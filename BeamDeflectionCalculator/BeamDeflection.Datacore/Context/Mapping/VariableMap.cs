using BeamDeflection.Domain.Constants;
using BeamDeflection.Domain.Model.BeamDeflectionDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeamDeflection.Datacore.Context.Mapping
{
    public class VariableMap : BaseEntityMap<Variable>
    {
        public VariableMap()
        {
            ToTable(DbConstants.Variable.Name, DbConstants.Variable.Schema);
            Property(x => x.Name)
               .HasColumnType("varchar")
               .HasMaxLength(200)
               .IsRequired();
            Property(x => x.Display)
                .HasColumnType("varchar")
                .HasMaxLength(10)
                .IsRequired();
            Property(x => x.Value)
                .HasColumnType("float")
                .IsRequired();
            HasRequired(x => x.Calculation)
                .WithMany(x => x.Variables)
                .HasForeignKey(x => x.CalculationId)
                .WillCascadeOnDelete(true);
            HasRequired(x => x.Unit)
               .WithMany(x => x.Variables)
               .HasForeignKey(x => x.UnitId)
               .WillCascadeOnDelete(false);


        }
    }
}
