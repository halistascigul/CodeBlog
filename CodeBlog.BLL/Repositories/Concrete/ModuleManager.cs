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
    public class ModuleManager : IModuleService
    {
        private readonly IModuleDal moduleDal;
        public ModuleManager(IModuleDal moduleDal)
        {
            this.moduleDal = moduleDal;
        }
        public EntityResult Delete(Module model)
        {
            try
            {
                if (moduleDal.Delete(model))
                    return new EntityResult("Silme işlemi başarılı", ResultState.Success);
                return new EntityResult("Silme işlemi sırasında bir hata oluştu", ResultState.Warning);
            }

            catch (Exception ex)
            {
                return new EntityResult("Database hatası: " + ex.ToInnestException().Message, ResultState.Error);
            }
        }

        public EntityResult<Module> Get(Expression<Func<Module, bool>> filter, params string[] includeList)
        {
            try
            {
                var module = moduleDal.Get(filter,includeList);
                if (module != null)
                    return new EntityResult<Module>(module, "Başarılı", ResultState.Success);
                return new EntityResult<Module>(null, "Hata oluştu", ResultState.Warning);
            }
            catch (Exception ex)
            {
                return new EntityResult<Module>(null,"Database hatası: " + ex.ToInnestException().Message, ResultState.Error);
            }
        }

        public EntityResult<Module> GetByRoleName(string name, params string[] includeList)
        {
            try
            {
                var module = moduleDal.Get(x => x.Name == name,includeList);
                if(module!=null)
                    return new EntityResult<Module>(module, "Başarılı", ResultState.Success);
                return new EntityResult<Module>(null, "Hata oluştu", ResultState.Warning);
            }
            catch (Exception ex)
            {
                return new EntityResult<Module>(null, "Database hatası: " + ex.ToInnestException().Message, ResultState.Error);
            }
        }

        public EntityResult<List<Module>> GetList(Expression<Func<Module, bool>> filter = null, params string[] includeList)
        {
            try
            {
                var modules = moduleDal.GetList(filter,includeList);
                if (modules != null)
                    return new EntityResult<List<Module>>(modules, "Başarılı", ResultState.Success);
                return new EntityResult<List<Module>>(null, "Hata oluştu", ResultState.Warning);
            }
            catch (Exception ex)
            {
                return new EntityResult<List<Module>>(null, "Database hatası: " + ex.ToInnestException().Message, ResultState.Error);
            }
        }

        public EntityResult Insert(Module model)
        {
            try
            {
                if(moduleDal.Insert(model))
                    return new EntityResult("Ekleme işlemi başarılı", ResultState.Success);
                return new EntityResult("Ekleme işlemi sırasında bir hata oluştu", ResultState.Warning);
            }

            catch (Exception ex)
            {
                return new EntityResult("Database hatası: " + ex.ToInnestException().Message, ResultState.Error);
            }
        }

        public EntityResult Update(Module model)
        {
            try
            {
                if (moduleDal.Update(model))
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
