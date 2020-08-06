using AutoMapper;
using CodeBlog.Infrastructure.DtoMapping;
using CodeBlog.Infrastructure.Modules;
using Ninject;
using Ninject.Web.Common.WebHost;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;

namespace CodeBlog.Web.MVC.UI
{
    public class MvcApplication : NinjectHttpApplication
    {

        protected override void OnApplicationStarted()
        {
            AreaRegistration.RegisterAllAreas();
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            Mapper.Initialize(x => x.AddProfile(new DtoMapper()));
            base.OnApplicationStarted();
        }
        protected override IKernel CreateKernel()
        {
            return new StandardKernel(new DalModule(),new BusinessModule());
        }
    }
}
