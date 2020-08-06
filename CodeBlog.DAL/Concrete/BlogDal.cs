using CodeBlog.CORE.Data.EF;
using CodeBlog.DAL.Abstract;
using CodeBlog.DataAccess.Context;
using CodeBlog.DOMAIN.Entities;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CodeBlog.DAL.Concrete
{
    public class BlogDal:Repository<CodeBlogDbContext,Blog>,IBlogDal
    {
        private readonly CodeBlogDbContext context;
        public BlogDal(CodeBlogDbContext context) : base(context)
        {
            this.context = context;
        }

        public List<Blog> GetListByCountDescending(int count, Expression<Func<Blog, bool>> filter = null, params string[] includeList)
        {
            IQueryable<Blog> query = null;
            try
            {
                query = context.Blogs;
                if (filter!=null)
                {
                    query = context.Blogs.Where(filter);
                }
                if (includeList != null)
                {
                    foreach (var item in includeList)
                    {
                        query = query.Include(item);
                    }
                }
                return query.OrderByDescending(x => x.Created).Take(count).ToList();
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
