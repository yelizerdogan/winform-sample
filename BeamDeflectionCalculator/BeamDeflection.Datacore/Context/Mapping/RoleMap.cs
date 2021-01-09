using BeamDeflection.Domain.Constants;
using BeamDeflection.Domain.Model.BeamDeflectionDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeamDeflection.Datacore.Context.Mapping
{
    public class RoleMap :BaseEntityMap<Role>
    {
        public RoleMap()
        {
            ToTable(DbConstants.Role.Name,DbConstants.Role.Schema);
            Property(x=>x.Name)
                .HasColumnType("varchar")
                .IsRequired();
            HasIndex(x=>x.Name)
                .IsUnique();
            HasMany(x=>x.Users)
                .WithMany(x=>x.Roles)
                .Map(x=> {
                    x.MapLeftKey("RoleId");
                    x.MapRightKey("UserId");
                    x.ToTable(DbConstants.ApplicationUserRole.Name,DbConstants.ApplicationUserRole.Schema);
                });
        }
    }
}
