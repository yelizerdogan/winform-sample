using BeamDeflection.Basecore.Data.EntityFramework.Persistence;
using BeamDeflection.Basecore.Model.Enums;
using BeamDeflection.Basecore.Model.ResultTypes;
using BeamDeflection.Datacore.Data;
using BeamDeflection.Domain.Model.BeamDeflectionDb;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeamDeflection.Datacore.Infrastructure
{
    public interface ILoadRepository : IRepository<Load>
    {
        BusinessResult<Load> InsertWithBeam(Load load, string beamname);
    }
    public class LoadRepository : Repository<BeamDeflectionDbContext, Load>, ILoadRepository
    {
        public LoadRepository(BeamDeflectionDbContext ctx) : base(ctx)
        {

        }

        public BusinessResult<Load> InsertWithBeam(Load load, string beamname)
        {
            BusinessResult<Load> result = null;
            try
            {
                using (IBeamRepository beamRepo = new BeamRepository(new BeamDeflectionDbContext()))
                {
                    var _beam = beamRepo.Get(x => x.Name == beamname).Result;
                    if (_beam!=null)
                    {
                        load.BeamId = _beam.ID;
                        var insert = this.Insert(load);
                        if (insert!=null)
                        {
                            result = new BusinessResult<Load>(load, "", BusinessResultType.Success);
                        }
                        else
                        {
                            result = new BusinessResult<Load>(null, "Kayıt başarısız.", BusinessResultType.NotSet);
                        }
                    }
                    else
                    {
                        result = new BusinessResult<Load>(null, "Kayıt başarısız. Kiriş bulunamadı.", BusinessResultType.NotSet);
                    }
                }
            }
            catch (Exception ex)
            {

                result = new BusinessResult<Load>(null, "Hata :" + ex.GetBaseException(), BusinessResultType.Error);
            }
            return result;
        }
    }
}
