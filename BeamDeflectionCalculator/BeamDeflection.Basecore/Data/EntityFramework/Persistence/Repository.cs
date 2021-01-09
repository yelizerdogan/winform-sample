using BeamDeflection.Basecore.Helpers.Common;
using BeamDeflection.Basecore.Model;
using BeamDeflection.Basecore.Model.Enums;
using BeamDeflection.Basecore.Model.ResultTypes;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BeamDeflection.Basecore.Data.EntityFramework.Persistence
{
    public class Repository<TContext, TEntity> : IRepository<TEntity>
       where TEntity : BaseModel
       where TContext : DbContext
    {

        protected readonly TContext Context;
        public Repository(TContext ctx)
        {
            Context = ctx;
        }


        public BusinessResult<List<TEntity>> GetList(params string[] includetables)
        {
            BusinessResult<List<TEntity>> result = null;
            try
            {
                IQueryable<TEntity> query = Context.Set<TEntity>();

                includetables.ToList().ForEach(tableName =>
                {
                    query = query.Include(tableName);
                });

                var entities = query.ToList();

                if (entities.Count == 0)
                {
                    result = new BusinessResult<List<TEntity>>(null, "Listede hiç bir kayıt yoktu.", BusinessResultType.Success);
                }
                else
                {
                    result = new BusinessResult<List<TEntity>>(entities,"",BusinessResultType.Success);
                }


            }
            catch (Exception ex)
            {
                result = new BusinessResult<List<TEntity>>(null, "Hata oluştu:" + ex.GetOriginalException().Message, BusinessResultType.Error);
            }
            return result;
        }

        public BusinessResult<List<TEntity>> FindList(Expression<Func<TEntity, bool>> filter, params string[] includetables)
        {
            BusinessResult<List<TEntity>> result = null;
            try
            {
                IQueryable<TEntity> query = Context.Set<TEntity>().Where(filter);

                includetables.ToList().ForEach(tableName =>
                {
                    query = query.Include(tableName);
                });

                var entities = query.ToList();

                if (entities.Count == 0)
                {
                    result = new BusinessResult<List<TEntity>>(null, "Listede hiç bir kayıt yoktu.", BusinessResultType.Success);
                }
                else
                {
                    result = new BusinessResult<List<TEntity>>(entities,"",BusinessResultType.Success);
                }


            }
            catch (Exception ex)
            {
                result = new BusinessResult<List<TEntity>>(null, "Hata oluştu:" + ex.GetOriginalException().Message, BusinessResultType.Error);
            }
            return result;
        }

        public BusinessResult<TEntity> Get(Expression<Func<TEntity, bool>> filter, params string[] includetables)
        {
            BusinessResult<TEntity> result = null;
            try
            {

                IQueryable<TEntity> query = Context.Set<TEntity>().Where(filter);

                includetables.ToList().ForEach(tableName =>
                {
                    query = query.Include(tableName);
                });
                var entity = query.SingleOrDefault(filter);
                if (entity == null)
                {
                    result = new BusinessResult<TEntity>(null, "Kayıt bulunamadı", BusinessResultType.Warning);
                }
                else
                {
                    result = new BusinessResult<TEntity>(entity,"",BusinessResultType.Success);
                }


            }
            catch (Exception ex)
            {
                result = new BusinessResult<TEntity>(null, "Hata oluştu:" + ex.GetOriginalException().Message, BusinessResultType.Error);
            }
            return result;
        }

        public BusinessResult<TEntity> Insert(TEntity entity)
        {
            BusinessResult<TEntity> result = null;
            try
            {

                DbEntityEntry<TEntity> inserted = Context.Entry<TEntity>(entity);
                inserted.State = EntityState.Added;

                if (Context.SaveChanges() > 0)
                {
                    result = new BusinessResult<TEntity>(entity,"Kayıt başarılı.",BusinessResultType.Success);
                }
                else
                {
                    result = new BusinessResult<TEntity>(null, "Bilinmeyen bir hata", BusinessResultType.Warning);
                }
            }
            catch (Exception ex)
            {
                result = new BusinessResult<TEntity>(entity, "Hata oluştu:" + ex.GetOriginalException().Message, BusinessResultType.Error);
            }
            return result;
        }

        public BusinessResult<int> InsertList(List<TEntity> entities)
        {
            BusinessResult<int> result = null;
            try
            {

                entities.ForEach(e =>
                {
                    DbEntityEntry<TEntity> inserted = Context.Entry<TEntity>(e);
                    inserted.State = EntityState.Added;
                });
                int contextResult = Context.SaveChanges();
                if (contextResult > 0)
                {
                    result = new BusinessResult<int>(contextResult);
                }
                else
                {
                    result = new BusinessResult<int>(0, "Bilinmeyen bir hata", BusinessResultType.Warning);
                }
            }
            catch (Exception ex)
            {
                result = new BusinessResult<int>(0, "Hata oluştu:" + ex.GetOriginalException().Message, BusinessResultType.Error);
            }
            return result;
        }

        public BusinessResult<TEntity> Update(TEntity entity)
        {
            BusinessResult<TEntity> result = null;
            try
            {

                DbEntityEntry<TEntity> updated = Context.Entry<TEntity>(entity);
                updated.State = EntityState.Modified;

                if (Context.SaveChanges() > 0)
                {
                    result = new BusinessResult<TEntity>(entity);
                }
                else
                {
                    result = new BusinessResult<TEntity>(null, "Bilinmeyen bir hata", BusinessResultType.Warning);
                }
            }
            catch (Exception ex)
            {
                result = new BusinessResult<TEntity>(entity, "Hata oluştu:" + ex.GetOriginalException().Message, BusinessResultType.Error);
            }
            return result;
        }

        public BusinessResult<int> UpdateList(List<TEntity> entities)
        {
            BusinessResult<int> result = null;
            try
            {
                entities.ForEach(e =>
                {
                    DbEntityEntry<TEntity> updated = Context.Entry<TEntity>(e);
                    updated.State = EntityState.Modified;
                });
                int contextResult = Context.SaveChanges();
                if (contextResult > 0)
                {
                    result = new BusinessResult<int>(contextResult);
                }
                else
                {
                    result = new BusinessResult<int>(0, "Bilinmeyen bir hata", BusinessResultType.Warning);
                }
            }
            catch (Exception ex)
            {
                result = new BusinessResult<int>(0, "Hata oluştu:" + ex.GetOriginalException().Message, BusinessResultType.Error);
            }
            return result;
        }

        public BusinessResult<bool> Delete(TEntity entity)
        {
            BusinessResult<bool> result = null;
            
            try
            {
                Context.Set<TEntity>().Remove(entity);
                if (Context.SaveChanges() > 0)
                {
                    result = new BusinessResult<bool>(true);
                }
                else
                {
                    result = new BusinessResult<bool>(false, "Bilinmeyen bir hata", BusinessResultType.Warning);
                }
            }
            catch (Exception ex)
            {
                result = new BusinessResult<bool>(false, "Hata oluştu:" + ex.GetOriginalException().Message, BusinessResultType.Error);
            }
            return result;
        }

        public BusinessResult<TEntity> MarkDeleted(TEntity entity)
        {
            BusinessResult<TEntity> result = null;
            try
            {
                var prop = typeof(TEntity).GetProperty("IsDeleted");
                if (prop != null)
                {
                    prop.SetValue(entity, true);
                    DbEntityEntry<TEntity> updated = Context.Entry<TEntity>(entity);
                    updated.State = EntityState.Modified;

                    if (Context.SaveChanges() > 0)
                    {
                        result = new BusinessResult<TEntity>(entity);
                    }
                    else
                    {
                        result = new BusinessResult<TEntity>(null, "Bilinmeyen bir hata", BusinessResultType.Warning);
                    }
                }
                else
                {
                    result = new BusinessResult<TEntity>(null, "Yanlış tipte entity gönderdin, Property Yok: IsDeleted.", BusinessResultType.Warning);
                }
            }
            catch (Exception ex)
            {
                result = new BusinessResult<TEntity>(entity, "Hata oluştu:" + ex.GetOriginalException().Message, BusinessResultType.Error);
            }
            return result;
        }

        public BusinessResult<TEntity> SaveAll()
        {
            BusinessResult<TEntity> result = null;
            try
            {
                if (Context.SaveChanges()>0)
                {
                    result = new BusinessResult<TEntity>(null, "Kaydetme başarılı.", BusinessResultType.Success);
                }
            }
            catch (Exception ex)
            {
                result = new BusinessResult<TEntity>(null, "Hata oluştu:" + ex.GetOriginalException().Message, BusinessResultType.Error);
            }
          
            return result;
        }

        public void Dispose()
        {
            Context.Dispose();
            GC.SuppressFinalize(this);
        }

    }
}
