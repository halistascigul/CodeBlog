using CodeBlog.CORE.Constants;
using CodeBlog.CORE.Extensions;
using CodeBlog.CORE.Model;
using CodeBlog.CORE.ResultTypes;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Migrations;
using System.Dynamic;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace CodeBlog.CORE.Data.EF
{
    public class Repository<TContext, T> : IRepository<T>
        where T : BaseEntity
        where TContext : DbContext
    {
        protected TContext ctx;

        public Repository(TContext context)
        {
            ctx = context;
        }

        public bool Delete(T model)
        {
            try
            {
                model.IsDeleted = true;
                model.IsActive = false;
                return ctx.SaveChanges() > 0;
            }
            catch (Exception)
            {
                // TODO: LOG
                return false;
            }
        }
        public T Get(Expression<Func<T, bool>> filter,params string[] includeList)
        {
            IQueryable<T> query = null;
            try
            {
                query = ctx.Set<T>();
                if (includeList!=null)
                {
                    foreach (var includeItem in includeList)
                    {
                        query = query.Include(includeItem);
                    }
                }
                return query.FirstOrDefault(filter);
            }
            catch (Exception)
            {
                // TODO: LOG
                return null;
            }
        }
        public List<T> GetList(Expression<Func<T, bool>> filter = null,params string[] includeList)
        {
            IQueryable<T> list = null;
            try
            {
                if (filter != null)
                {
                    list = ctx.Set<T>().Where(filter);
                }
                else
                {
                    list = ctx.Set<T>();
                }
                if (includeList != null)
                {
                    foreach (var includeItem in includeList)
                    {
                        list = list.Include(includeItem);
                    }
                }

                return list.ToList();
            }
            catch (Exception ex)
            {
                // TODO : LOG
                return null;
            }
        }

        public bool Insert(T model)
        {
            try
            {
                ctx.Set<T>().Add(model);
                return ctx.SaveChanges() > 0;
            }
            catch (Exception)
            {
                // TODO: LOG
                return false;
            }
        }

        public bool Update(T model)
        {
            try
            {
                model.Updated = DateTime.Now;
                ctx.Set<T>().AddOrUpdate(x => x.Id, model);


                //ctx.Entry(model).State = EntityState.Modified;


                return ctx.SaveChanges() > 0;
            }
            catch (Exception)
            {
                // TODO: LOG
                return false;
            }
        }
    }
}
