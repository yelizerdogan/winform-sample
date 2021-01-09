using BeamDeflection.Basecore.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeamDeflection.Datacore.Context.Mapping
{
    public class BaseEntityMap<T> : EntityTypeConfiguration<T> where T:BaseEntity
    {
        public BaseEntityMap()
        {
            HasKey(x=>x.ID);
            Property(x=>x.CreatedAt)
                .HasColumnType("datetime2")
                .IsRequired();
            Property(x => x.UpdatedAt)
                .HasColumnType("datetime2")
                .IsRequired();
            
        }
    }
}
