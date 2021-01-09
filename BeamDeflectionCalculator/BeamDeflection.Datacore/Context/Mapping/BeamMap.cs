using BeamDeflection.Domain.Constants;
using BeamDeflection.Domain.Model.BeamDeflectionDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeamDeflection.Datacore.Context.Mapping
{
    public class BeamMap :BaseEntityMap<Beam>
    {
        public BeamMap()
        {
            ToTable(DbConstants.Beam.Name, DbConstants.Beam.Schema);
            Property(x=>x.Name)
                .HasColumnType("varchar")
                .HasMaxLength(150)
                .IsRequired();
        }
    }
}
