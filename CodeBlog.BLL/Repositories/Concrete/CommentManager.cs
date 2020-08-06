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
    public class CommentManager:ICommentService
    {
        private readonly ICommentDal commentDal;
        public CommentManager(ICommentDal _commentDal)
        {
            commentDal = _commentDal;
        }

        public EntityResult<Comment> Get(Expression<Func<Comment, bool>> filter, params string[] includeList)
        {
            try
            {
                var module = commentDal.Get(filter, includeList);
                if (module != null)
                    return new EntityResult<Comment>(module, "Başarılı", ResultState.Success);
                return new EntityResult<Comment>(null, "Hata oluştu", ResultState.Warning);
            }
            catch (Exception ex)
            {
                return new EntityResult<Comment>(null, "Database hatası: " + ex.ToInnestException().Message, ResultState.Error);
            }
        }
        public EntityResult Delete(Comment model)
        {
            try
            {
                if (commentDal.Delete(model))
                    return new EntityResult("Silme işlemi başarılı", ResultState.Success);
                return new EntityResult("Silme işlemi sırasında bir hata oluştu", ResultState.Warning);
            }

            catch (Exception ex)
            {
                return new EntityResult("Database hatası: " + ex.ToInnestException().Message, ResultState.Error);
            }
        }

        public EntityResult<List<Comment>> GetList(Expression<Func<Comment, bool>> filter = null, params string[] includeList)
        {
            try
            {
                var categorys = commentDal.GetList(filter, includeList);
                if (categorys != null)
                    return new EntityResult<List<Comment>>(categorys, "Başarılı", ResultState.Success);
                return new EntityResult<List<Comment>>(null, "Hata oluştu", ResultState.Warning);
            }
            catch (Exception ex)
            {
                return new EntityResult<List<Comment>>(null, "Database hatası: " + ex.ToInnestException().Message, ResultState.Error);
            }
        }

        public EntityResult Insert(Comment model)
        {
            try
            {
                if (commentDal.Insert(model))
                    return new EntityResult("Ekleme işlemi başarılı", ResultState.Success);
                return new EntityResult("Ekleme işlemi sırasında bir hata oluştu", ResultState.Warning);
            }

            catch (Exception ex)
            {
                return new EntityResult("Database hatası: " + ex.ToInnestException().Message, ResultState.Error);
            }
        }

        public EntityResult Update(Comment model)
        {
            try
            {
                if (commentDal.Update(model))
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
