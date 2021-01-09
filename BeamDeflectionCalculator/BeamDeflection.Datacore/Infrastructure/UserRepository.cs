using BeamDeflection.Basecore.Data.EntityFramework.Persistence;
using BeamDeflection.Basecore.Helpers.Common;
using BeamDeflection.Basecore.Model.Enums;
using BeamDeflection.Basecore.Model.ResultTypes;
using BeamDeflection.Datacore.Data;
using BeamDeflection.Domain.Constants;
using BeamDeflection.Domain.Model.BeamDeflectionDb;
using BeamDeflection.Domain.ResultTypes;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BeamDeflection.Datacore.Infrastructure
{
    public interface IUserRepository : IRepository<ApplicationUser>
    {
        UserResult Login(string username, string password);
        UserResult Register(string username, string password, string title, string name, string surname,string rolename="", bool isActive=false);
        UserResult InsertUserRoles(ApplicationUser user, Role role);
        BusinessResult<List<ViewUserRoles>> GetAllUsersWithRoles();

    }


    public class UserRepository : Repository<BeamDeflectionDbContext, ApplicationUser>, IUserRepository
    {
        public UserRepository(BeamDeflectionDbContext ctx)
            : base(ctx)
        {

        }
        public UserResult Register(string username, string password, string title, string name, string surname, string rolename="",bool isAvtive=false)
        {
            UserResult result = null;
            try
            {
                var checkUser = Context.Users.SingleOrDefault(x => x.Username == username);
                if (checkUser!=null)
                {
                    result = new UserResult(UserResultType.NotConfirmed, null, "Böyle bir kullanıcı mevcut.", BusinessResultType.Warning);
                    return result;
                }
                ApplicationUser user = new ApplicationUser
                {
                    Username=username,
                    Password=password.GetMD5Hash(),
                    Title=title,
                    Name=name,
                    Surname=surname,
                    IsActive=isAvtive
                };
                this.Insert(user);
                using (IRoleRepository roleRepo= new RoleRepository(new BeamDeflectionDbContext()))
                {
                    Role role = null;
                    if (rolename=="")
                    {
                        role = roleRepo.Get(x => x.Name == "guest").Result;
                    }
                    else
                    {
                        role = roleRepo.Get(x => x.Name == rolename).Result;
                    }
                    
                    this.InsertUserRoles(user, role);
                }
                result = new UserResult(UserResultType.Authenticated, user, "Kayıt başarılı.", BusinessResultType.Success);
            }
            catch (Exception ex)
            {

                result = new UserResult(UserResultType.NotConfirmed, null, "Hata:" + ex.GetOriginalException().Message, BusinessResultType.Error);
            }
      
            return result;
        }

        public UserResult Login(string username, string password)
        {
            UserResult result = null;
            try
            {
                password = password.GetMD5Hash();
                var user = Context.Users.SingleOrDefault(u => u.Username == username && u.Password == password);
                if (user == null)
                {
                    result = new UserResult(UserResultType.NotFound, null, "Kullanıcı bulunamadı.", BusinessResultType.Info);
                }
                else
                {
                    if (!user.IsActive)
                    {
                        result = new UserResult(UserResultType.Blocked, user, "Bu kullanıcı onay beklemektedir", BusinessResultType.Info);
                    }
                    else if (user.IsDeleted)
                    {
                        result = new UserResult(UserResultType.NotFound, user, "Bu kullanıcı silinmiştir.", BusinessResultType.Info);
                    }
                    else
                    {
                        result = new UserResult(UserResultType.Authenticated, user, "", BusinessResultType.Success);
                    }
                }

            }
            catch (Exception ex)
            {
                result = new UserResult(UserResultType.UnAuthorized, null, "Hata:" + ex.GetOriginalException().Message, BusinessResultType.Error);
            }
            return result;
        }

      

        public UserResult InsertUserRoles(ApplicationUser user, Role role)
        { 
            UserResult result = null;

            try
            {

                int rowCount = Context.Database.ExecuteSqlCommand("insert Intersections.UserRoles(RoleId,UserId) values(@RoleId,@UserId)",new SqlParameter("@RoleId",role.ID), new SqlParameter("@UserId",user.ID));
                Context.SaveChanges();
                if (rowCount>0)
                {
                    result = new UserResult(UserResultType.Authenticated, null, "Kayıt başarılı.", BusinessResultType.Success);
                }
                else
                {
                    result = new UserResult(UserResultType.NotFound, null, "Kayıt başarısız.", BusinessResultType.NotSet);
                }
            }
            catch (Exception ex)
            {
                result = new UserResult(UserResultType.NotFound, null, ex.GetBaseException().ToString(), BusinessResultType.Error);
            }

            return result;
        }

        public BusinessResult<List<ViewUserRoles>> GetAllUsersWithRoles()
        {
            BusinessResult<List<ViewUserRoles>> result = null;
            try
            {
                var userWithRoles = Context.Database.SqlQuery<ViewUserRoles>("Select u.Username, u.Name,u.Surname,u.Title,r.Name RoleName,u.IsActive,u.IsDeleted from Management.Users u join Intersections.UserRoles ur on u.ID=ur.UserId join Management.Roles r on r.ID=ur.RoleId").ToList();
                if (userWithRoles==null)
                {
                    result = new BusinessResult<List<ViewUserRoles>>(null, "", BusinessResultType.NotSet);
                   
                }
                else
                {
                    result = new BusinessResult<List<ViewUserRoles>>(userWithRoles, "", BusinessResultType.Success);
                }

            }
            catch (Exception ex)
            {

                result = new BusinessResult<List<ViewUserRoles>>(null, "Hata oluştu:" + ex.GetOriginalException().Message, BusinessResultType.Error);
            }
            return result;
        
        }
    }
}
