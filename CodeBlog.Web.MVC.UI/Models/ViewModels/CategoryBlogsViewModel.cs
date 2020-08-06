using CodeBlog.DTO.BlogDTOs;
using CodeBlog.DTO.CategoryDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CodeBlog.Web.MVC.UI.Models.ViewModels
{
    public class CategoryBlogsViewModel
    {
        public List<BlogListDto> Blogs { get; set; }
        public List<BlogListDto> RecentBlogs { get; set; }
        public List<CategoryMenuDto> Categories { get; set; }
    }
}