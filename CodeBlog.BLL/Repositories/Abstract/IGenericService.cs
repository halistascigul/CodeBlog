using CodeBlog.CORE.Model;
using CodeBlog.CORE.ResultTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CodeBlog.BLL.Repositories.Abstract
{
    public interface IGenericService<T>
        where T:BaseEntity
    {
        EntityResult Insert(T model);
        EntityResult Update(T model);
        EntityResult Delete(T model);
        EntityResult<List<T>> GetList(Expression<Func<T, bool>> filter = null, params string[] includeList);
        EntityResult<T> Get(Expression<Func<T, bool>> filter, params string[] includeList);
    }
}
