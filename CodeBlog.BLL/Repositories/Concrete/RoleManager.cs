using CodeBlog.BLL.Repositories.Abstract;
using CodeBlog.CORE.Constants;
using CodeBlog.CORE.Extensions;
using CodeBlog.CORE.ResultTypes;
using CodeBlog.DAL.Abstract;
using CodeBlog.DOMAIN.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CodeBlog.BLL.Repositories.Concrete
{
   public class RoleManager:IRoleService
    {
        private readonly IRoleDal roleDal;
        public RoleManager(IRoleDal _roleDal)
        {
            roleDal = _roleDal;
        }

        public EntityResult<Role> Get(Expression<Func<Role, bool>> filter, params string[] includeList)
        {
            try
            {
                var module = roleDal.Get(filter, includeList);
                if (module != null)
                    return new EntityResult<Role>(module, "Başarılı", ResultState.Success);
                return new EntityResult<Role>(null, "Hata oluştu", ResultState.Warning);
            }
            catch (Exception ex)
            {
                return new EntityResult<Role>(null, "Database hatası: " + ex.ToInnestException().Message, ResultState.Error);
            }
        }
        public EntityResult Delete(Role model)
        {
            try
            {
                if (roleDal.Delete(model))
                    return new EntityResult("Silme işlemi başarılı", ResultState.Success);
                return new EntityResult("Silme işlemi sırasında bir hata oluştu", ResultState.Warning);
            }

            catch (Exception ex)
            {
                return new EntityResult("Database hatası: " + ex.ToInnestException().Message, ResultState.Error);
            }
        }

        public EntityResult<List<Role>> GetList(Expression<Func<Role, bool>> filter = null, params string[] includeList)
        {
            try
            {
                var categorys = roleDal.GetList(filter, includeList);
                if (categorys != null)
                    return new EntityResult<List<Role>>(categorys, "Başarılı", ResultState.Success);
                return new EntityResult<List<Role>>(null, "Hata oluştu", ResultState.Warning);
            }
            catch (Exception ex)
            {
                return new EntityResult<List<Role>>(null, "Database hatası: " + ex.ToInnestException().Message, ResultState.Error);
            }
        }

        public EntityResult Insert(Role model)
        {
            try
            {
                if (roleDal.Insert(model))
                    return new EntityResult("Ekleme işlemi başarılı", ResultState.Success);
                return new EntityResult("Ekleme işlemi sırasında bir hata oluştu", ResultState.Warning);
            }

            catch (Exception ex)
            {
                return new EntityResult("Database hatası: " + ex.ToInnestException().Message, ResultState.Error);
            }
        }

        public EntityResult Update(Role model)
        {
            try
            {
                if (roleDal.Update(model))
                    return new EntityResult("Ekleme işlemi başarılı", ResultState.Success);
                return new EntityResult("Ekleme işlemi sırasında bir hata oluştu", ResultState.Warning);
            }

            catch (Exception ex)
            {
                return new EntityResult("Database hatası: " + ex.ToInnestException().Message, ResultState.Error);
            }
        }
    }
}
