using BeamDeflection.Basecore.Data.EntityFramework.Persistence;
using BeamDeflection.Datacore.Data;
using BeamDeflection.Domain.Model.BeamDeflectionDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeamDeflection.Datacore.Infrastructure
{
    public interface IVariableRepository : IRepository<Variable>
    {

    }
    public class VariableRepository : Repository<BeamDeflectionDbContext, Variable>, IVariableRepository
    {
        public VariableRepository(BeamDeflectionDbContext ctx) : base(ctx)
        {

        }
    }
}
