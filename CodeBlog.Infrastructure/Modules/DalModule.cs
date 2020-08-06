using AutoMapper;
using CodeBlog.BLL.Repositories.Abstract;
using CodeBlog.BLL.Repositories.Concrete;
using CodeBlog.DAL.Abstract;
using CodeBlog.DAL.Concrete;
using Ninject.Modules;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBlog.Infrastructure.Modules
{
    public class DalModule : NinjectModule
    {
        public override void Load()
        {
            Bind<IModuleDal>().To<ModuleDal>().InSingletonScope();
            Bind<IBlogDal>().To<BlogDal>().InSingletonScope();
            Bind<ICategoryDal>().To<CategoryDal>().InSingletonScope();
            Bind<ICommentDal>().To<CommentDal>().InSingletonScope();
            Bind<IRoleDal>().To<RoleDal>().InSingletonScope();
            Bind<ISocialDal>().To<SocialDal>().InSingletonScope();
            Bind<ITicketDal>().To<TicketDal>().InSingletonScope();
            Bind<ITicketResponseDal>().To<TicketResponseDal>().InSingletonScope();
            Bind<IUserDal>().To<UserDal>().InSingletonScope();

        }
    }
}
