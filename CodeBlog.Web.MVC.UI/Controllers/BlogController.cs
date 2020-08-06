using AutoMapper;
using CodeBlog.BLL.Repositories.Abstract;
using CodeBlog.DOMAIN.Entities;
using CodeBlog.DTO.BlogDTOs;
using CodeBlog.DTO.CategoryDTOs;
using CodeBlog.DTO.CommentDTOs;
using CodeBlog.Web.MVC.UI.Filters;
using CodeBlog.Web.MVC.UI.Manage.Sessions;
using CodeBlog.Web.MVC.UI.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CodeBlog.Web.MVC.UI.Controllers
{
    public class BlogController : Controller
    {
        // GET: Blog
        private readonly IBlogService blogService;
        private readonly ICategoryService categoryService;
        private readonly ICommentService commentService;
        public BlogController(IBlogService blogService,ICategoryService categoryService,ICommentService commentService)
        {
            this.blogService=blogService;
            this.categoryService = categoryService;
            this.commentService = commentService;
        }
        public ActionResult BlogsByCategory(string catName)
        {
            PageSessions.ActivePage = null;
            ViewBag.CategoryName = catName;
            CategoryBlogsViewModel vm = new CategoryBlogsViewModel();
            vm.Blogs = Mapper.Map<List<BlogListDto>>(blogService.GetList(x => x.Category.Name == catName && x.IsActive && !x.IsDeleted, "Owner").Data);
            vm.Categories = Mapper.Map<List<CategoryMenuDto>>(categoryService.GetList(x => x.IsActive).Data);
            vm.RecentBlogs = Mapper.Map<List<BlogListDto>>(blogService.GetListByCountDescending(5,x=>x.IsActive,"Owner").Data);
            return View(vm);
        }


        [HttpPost]
        public ActionResult NewComment(NewCommentDto commentDto)
        {
            commentDto.OwnerId = UserSessions.CurrentUser.Id;
            var result = commentService.Insert(Mapper.Map<Comment>(commentDto));
            switch (result.State)
            {
                case CORE.Constants.ResultState.Success:
                    return Redirect(Request.UrlReferrer.ToString());
                default:
                    return View();
            }
        }
        
      
        public ActionResult SingleBlog(string url)
        {
            BlogSessions.ActiveBlogUrl = url;
            SingleBlogViewModel vm = new SingleBlogViewModel();
            vm.Blog = Mapper.Map<SingleBlogDto>(blogService.Get(x => x.Url == url,"Owner","Category","Comments").Data);
            var blog = blogService.Get(x => x.Url == url).Data;
            blog.Views += 1;
            blogService.Update(blog);
            vm.Categories = Mapper.Map<List<CategoryMenuDto>>(categoryService.GetList(x => x.IsActive).Data);
            vm.RecentBlogs = Mapper.Map<List<BlogListDto>>(blogService.GetList(x => x.IsActive && x.CategoryId==vm.Blog.CategoryId,"Owner").Data.Take(5));
            return View(vm);
        }

        [HttpPost]
        public ActionResult LikeIt(int id)
        {
            var blog = blogService.Get(x => x.Id == id).Data;
            blog.Likes += 1;
            var result = blogService.Update(blog);

            Dictionary<string, object> dictionary = new Dictionary<string, object>();

            switch (result.State)
            {
                case CORE.Constants.ResultState.Success:
                    dictionary.Add("status", true);
                    dictionary.Add("likes", blog.Likes);
                    return Json(dictionary);
                default:
                    dictionary.Add("status", false);
                    dictionary.Add("likes", null);
                    return Json(dictionary);
            }
           
        }
    }
}