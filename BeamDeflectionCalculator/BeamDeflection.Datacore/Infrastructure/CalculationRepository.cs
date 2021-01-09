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
    public interface ICalculationRepository : IRepository<Calculation>
    {

    }
    public class CalculationRepository : Repository<BeamDeflectionDbContext, Calculation>, ICalculationRepository
    {
        public CalculationRepository(BeamDeflectionDbContext ctx) : base(ctx)
        {

        }
    }
}
