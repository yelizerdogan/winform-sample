using BeamDeflection.Basecore.Data.EntityFramework.Persistence;
using BeamDeflection.Basecore.Model.ResultTypes;
using BeamDeflection.Datacore.Data;
using BeamDeflection.Domain.Model.BeamDeflectionDb;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeamDeflection.Datacore.Infrastructure
{
    public interface IRoleRepository:IRepository<Role>
    {
      
    }
    public class RoleRepository :Repository<BeamDeflectionDbContext,Role>,IRoleRepository
    {
        public RoleRepository(BeamDeflectionDbContext ctx) :base(ctx)
        {
            

        }
    
    }
}
