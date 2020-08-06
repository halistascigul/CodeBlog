using CodeBlog.BLL.Repositories.Abstract;
using CodeBlog.BLL.Repositories.Concrete;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBlog.Infrastructure.Modules
{
    public class BusinessModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IModuleService>().To<ModuleManager>().InSingletonScope();
            Bind<ICategoryService>().To<CategoryManager>().InSingletonScope();
            Bind<IBlogService>().To<BlogManager>().InSingletonScope();
            Bind<IUserService>().To<UserManager>().InSingletonScope();
            Bind<IRoleService>().To<RoleManager>().InSingletonScope();
            Bind<ICommentService>().To<CommentManager>().InSingletonScope();
        }
    }
}
