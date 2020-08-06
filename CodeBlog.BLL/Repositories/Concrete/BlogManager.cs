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
    public class BlogManager : IBlogService
    {
        private readonly IBlogDal blogDal;
        public BlogManager(IBlogDal _blogDal)
        {
            blogDal = _blogDal;
        }
        public EntityResult<Blog> Get(Expression<Func<Blog, bool>> filter, params string[] includeList)
        {
            try
            {
                var module = blogDal.Get(filter, includeList);
                if (module != null)
                    return new EntityResult<Blog>(module, "Başarılı", ResultState.Success);
                return new EntityResult<Blog>(null, "Hata oluştu", ResultState.Warning);
            }
            catch (Exception ex)
            {
                return new EntityResult<Blog>(null, "Database hatası: " + ex.ToInnestException().Message, ResultState.Error);
            }
        }
        public EntityResult Delete(Blog model)
        {
            try
            {
                if (blogDal.Delete(model))
                    return new EntityResult("Silme işlemi başarılı", ResultState.Success);
                return new EntityResult("Silme işlemi sırasında bir hata oluştu", ResultState.Warning);
            }

            catch (Exception ex)
            {
                return new EntityResult("Database hatası: " + ex.ToInnestException().Message, ResultState.Error);
            }
        }

        public EntityResult<List<Blog>> GetList(Expression<Func<Blog, bool>> filter = null, params string[] includeList)
        {
            try
            {
                var categorys = blogDal.GetList(filter, includeList);
                if (categorys != null)
                    return new EntityResult<List<Blog>>(categorys, "Başarılı", ResultState.Success);
                return new EntityResult<List<Blog>>(null, "Hata oluştu", ResultState.Warning);
            }
            catch (Exception ex)
            {
                return new EntityResult<List<Blog>>(null, "Database hatası: " + ex.ToInnestException().Message, ResultState.Error);
            }
        }

        public EntityResult Insert(Blog model)
        {
            try
            {
                if (blogDal.Insert(model))
                    return new EntityResult("Ekleme işlemi başarılı", ResultState.Success);
                return new EntityResult("Ekleme işlemi sırasında bir hata oluştu", ResultState.Warning);
            }

            catch (Exception ex)
            {
                return new EntityResult("Database hatası: " + ex.ToInnestException().Message, ResultState.Error);
            }
        }

        public EntityResult Update(Blog model)
        {
            try
            {
                if (blogDal.Update(model))
                    return new EntityResult("Ekleme işlemi başarılı", ResultState.Success);
                return new EntityResult("Ekleme işlemi sırasında bir hata oluştu", ResultState.Warning);
            }

            catch (Exception ex)
            {
                return new EntityResult("Database hatası: " + ex.ToInnestException().Message, ResultState.Error);
            }
        }

        public EntityResult<List<Blog>> GetListByCountDescending(int count, Expression<Func<Blog, bool>> filter = null, params string[] includeList)
        {
            try
            {
                var blogs = blogDal.GetListByCountDescending(count, filter, includeList);
                if (blogs != null)
                    return new EntityResult<List<Blog>>(blogs, "Success", ResultState.Success);
                return new EntityResult<List<Blog>>(null, "Warning", ResultState.Warning);
            }
            catch (Exception ex)
            {
                return new EntityResult<List<Blog>>(null, ex.ToInnestException().Message, ResultState.Error);
            }
        }
    }
}
