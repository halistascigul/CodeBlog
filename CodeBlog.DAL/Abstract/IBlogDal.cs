using CodeBlog.CORE.Data.EF;
using CodeBlog.DOMAIN.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CodeBlog.DAL.Abstract
{
    public interface IBlogDal:IRepository<Blog>
    {
        List<Blog> GetListByCountDescending(int count, Expression<Func<Blog, bool>> filter = null, params string[] includeList);
    }
}
