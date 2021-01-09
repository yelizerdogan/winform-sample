using BeamDeflection.Basecore.Model;
using BeamDeflection.Basecore.Model.ResultTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BeamDeflection.Basecore.Data.EntityFramework.Persistence
{
    public interface IRepository<T> : IDisposable where T : BaseModel
    {

        BusinessResult<List<T>> GetList(params string[] includetables);

        BusinessResult<List<T>> FindList(Expression<Func<T, bool>> filter, params string[] includetables);

        BusinessResult<T> Get(Expression<Func<T, bool>> filter, params string[] includetables);

        BusinessResult<T> Insert(T entity);

        BusinessResult<int> InsertList(List<T> entities);

        BusinessResult<T> Update(T entity);

        BusinessResult<int> UpdateList(List<T> entities);

        BusinessResult<bool> Delete(T entity);

        BusinessResult<T> MarkDeleted(T entity);
        BusinessResult<T> SaveAll();

    }
}
