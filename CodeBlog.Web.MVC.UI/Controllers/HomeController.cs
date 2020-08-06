using AutoMapper;
using CodeBlog.BLL.Repositories.Abstract;
using CodeBlog.CORE.ResultTypes;
using CodeBlog.DataAccess.Context;
using CodeBlog.DOMAIN.Entities;
using CodeBlog.DTO.BlogDTOs;
using CodeBlog.DTO.ModuleDTOs;
using CodeBlog.Infrastructure.DtoMapping;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CodeBlog.Web.MVC.UI.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        private readonly IBlogService blogService;
        public HomeController(IBlogService _blogService)
        {
            blogService = _blogService;
        }

        public ActionResult Index()
        {
            //var data = new List<Blog>();
            //using (var context = new CodeBlogDbContext())
            //{
            //    var query = context.Blogs.Where(x => x.IsActive).Include("Owner");
            //    data = data.ToList();
            //}


            var result = blogService.GetList(x => x.IsActive && !x.IsDeleted,"Owner");
            switch (result.State)
            {
                case CORE.Constants.ResultState.Success:
                    return View(Mapper.Map<List<BlogListDto>>(result.Data));
                default:
                    return HttpNotFound(result.Message);
            }
        }
    }
}