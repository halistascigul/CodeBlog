using CodeBlog.CORE.Model;
using CodeBlog.CORE.ResultTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CodeBlog.CORE.Data.EF
{
    public interface IRepository<T>
        where T : BaseEntity
    {
        // DONT REPEAT YOURSELF
        bool Insert(T model);
        bool Update(T model);
        bool Delete(T model);
        List<T> GetList(Expression<Func<T,bool>> filter=null, params string[] includeList);
        T Get(Expression<Func<T, bool>> filter, params string[] includeList);
    }
}
