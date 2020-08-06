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
    public class CategoryManager : ICategoryService
    {
        private readonly ICategoryDal categoryDal;
        public CategoryManager(ICategoryDal _categoryDal)
        {
            categoryDal = _categoryDal;
        }
        public EntityResult<Category> Get(Expression<Func<Category, bool>> filter, params string[] includeList)
        {
            try
            {
                var module = categoryDal.Get(filter,includeList);
                if (module != null)
                    return new EntityResult<Category>(module, "Başarılı", ResultState.Success);
                return new EntityResult<Category>(null, "Hata oluştu", ResultState.Warning);
            }
            catch (Exception ex)
            {
                return new EntityResult<Category>(null, "Database hatası: " + ex.ToInnestException().Message, ResultState.Error);
            }
        }
        public EntityResult Delete(Category model)
        {
            try
            {
                if (categoryDal.Delete(model))
                    return new EntityResult("Silme işlemi başarılı", ResultState.Success);
                return new EntityResult("Silme işlemi sırasında bir hata oluştu", ResultState.Warning);
            }

            catch (Exception ex)
            {
                return new EntityResult("Database hatası: " + ex.ToInnestException().Message, ResultState.Error);
            }
        }

        public EntityResult<List<Category>> GetList(Expression<Func<Category, bool>> filter = null, params string[] includeList)
        {
            try
            {
                var categorys = categoryDal.GetList(filter,includeList);
                if (categorys != null)
                    return new EntityResult<List<Category>>(categorys, "Başarılı", ResultState.Success);
                return new EntityResult<List<Category>>(null, "Hata oluştu", ResultState.Warning);
            }
            catch (Exception ex)
            {
                return new EntityResult<List<Category>>(null, "Database hatası: " + ex.ToInnestException().Message, ResultState.Error);
            }
        }

        public EntityResult Insert(Category model)
        {
            try
            {
                if (categoryDal.Insert(model))
                    return new EntityResult("Ekleme işlemi başarılı", ResultState.Success);
                return new EntityResult("Ekleme işlemi sırasında bir hata oluştu", ResultState.Warning);
            }

            catch (Exception ex)
            {
                return new EntityResult("Database hatası: " + ex.ToInnestException().Message, ResultState.Error);
            }
        }

        public EntityResult Update(Category model)
        {
            try
            {
                if (categoryDal.Update(model))
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
