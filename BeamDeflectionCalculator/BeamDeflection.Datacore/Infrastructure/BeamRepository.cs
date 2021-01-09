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
    public interface IBeamRepository : IRepository<Beam>
    {

    }
    public class BeamRepository : Repository<BeamDeflectionDbContext, Beam>, IBeamRepository
    {
        public BeamRepository(BeamDeflectionDbContext ctx) : base(ctx)
        {

        }
    }
}
