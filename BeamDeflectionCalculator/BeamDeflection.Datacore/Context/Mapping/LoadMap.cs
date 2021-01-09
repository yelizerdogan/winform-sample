using BeamDeflection.Domain.Constants;
using BeamDeflection.Domain.Model.BeamDeflectionDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeamDeflection.Datacore.Context.Mapping
{
    public class LoadMap :BaseEntityMap<Load>
    {
        public LoadMap()
        {
            ToTable(DbConstants.Load.Name, DbConstants.Load.Schema);
            Property(x=>x.Name)
                .HasColumnType("varchar")
                .IsRequired();
            HasRequired(x=>x.Beam)
                .WithMany(x=>x.Loads)
                .HasForeignKey(x=>x.BeamId)
                .WillCascadeOnDelete(true);
        }
    }
}
