using BeamDeflection.Domain.Constants;
using BeamDeflection.Domain.Model.BeamDeflectionDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeamDeflection.Datacore.Context.Mapping
{
    public class ApplicationUserMap :BaseEntityMap<ApplicationUser>
    {
        public ApplicationUserMap()
        {
            ToTable(DbConstants.ApplicationUser.Name,DbConstants.ApplicationUser.Schema);
       
            Property(x=>x.LastLogin)
                .HasColumnType("datetime2")
                .IsRequired();
            Property(x=>x.Name)
                .HasColumnType("varchar")
                .HasMaxLength(20)
                .IsRequired();
            Property(x => x.Surname)
                .HasColumnType("varchar")
                .HasMaxLength(30);
            Property(x=>x.Title)
                .HasColumnType("varchar")
                .HasMaxLength(50);
            Property(x => x.Password)
                .HasColumnType("nchar")
                .HasMaxLength(64)
                .IsRequired();
            Property(x=>x.Username)
                .HasColumnType("varchar")
                .HasMaxLength(20)
                .IsRequired();
            HasIndex(x => x.Username)
                .IsUnique();

        }
    }
}
