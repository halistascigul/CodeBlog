using AutoMapper;
using CodeBlog.BLL.Repositories.Abstract;
using CodeBlog.DTO.CategoryDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace CodeBlog.Web.MVC.UI.Controllers
{
    public class CommonController : Controller
    {
        // GET: Common
        private readonly ICategoryService categoryService;
        public CommonController(ICategoryService _categoryService)
        {
            categoryService = _categoryService;
        }
        public PartialViewResult RenderHeader()
        {
            var model = Mapper.Map<List<CategoryMenuDto>>(categoryService.GetList().Data);
            return PartialView("~/Views/Shared/header.cshtml",model);
        }

        public PartialViewResult RenderFooter()
        {
            return PartialView("~/Views/Shared/footer.cshtml");
        }
    }
}