using BeamDeflection.Domain.Constants;
using BeamDeflection.Domain.Model.BeamDeflectionDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeamDeflection.Datacore.Context.Mapping
{
    public class UnitMap :BaseEntityMap<Unit>
    {
        public UnitMap()
        {
            ToTable(DbConstants.Unit.Name,DbConstants.Unit.Schema);
            Property(x=>x.Name)
                .HasColumnType("nvarchar")
                .HasMaxLength(100)
                .IsRequired();
            Property(x => x.Display)
                .HasColumnType("nvarchar")
                .HasMaxLength(10)
                .IsRequired();
        }
    }
}
