using CodeBlog.CORE.ResultTypes;
using CodeBlog.DOMAIN.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CodeBlog.BLL.Repositories.Abstract
{
    public interface IBlogService:IGenericService<Blog>
    {
        EntityResult<List<Blog>> GetListByCountDescending(int count, Expression<Func<Blog, bool>> filter = null, params string[] includeList);
    }
}
