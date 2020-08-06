using AutoMapper;
using CodeBlog.DOMAIN.Entities;
using CodeBlog.DTO.BlogDTOs;
using CodeBlog.DTO.CategoryDTOs;
using CodeBlog.DTO.CommentDTOs;
using CodeBlog.DTO.ModuleDTOs;
using CodeBlog.DTO.UserDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace CodeBlog.Infrastructure.DtoMapping
{
   public class DtoMapper : Profile
    {
        public DtoMapper()
        {
            // Module
            CreateMap<ModuleDto, Module>();
            CreateMap<Module, ModuleDto>();

            // Category
            CreateMap<CategoryMenuDto, Category>();
            CreateMap<Category, CategoryMenuDto>();

            // Blog
            CreateMap<BlogListDto, Blog>();
            CreateMap<Blog, BlogListDto>().ForMember("OwnerName",x=>x.MapFrom(y=>y.Owner.FullName)).ForMember("OwnerJob",x=>x.MapFrom(y=>y.Owner.Job));
            CreateMap<SingleBlogDto, Blog>();
            CreateMap<Blog, SingleBlogDto>()
                .ForMember("OwnerName", x => x.MapFrom(y => y.Owner.FullName))
                .ForMember("OwnerPicturePath", x => x.MapFrom(y => y.Owner.ProfilePicturePath))
                .ForMember("OwnerAboutText", x => x.MapFrom(y => y.Owner.AboutText))
                .ForMember("CategoryName", x => x.MapFrom(y => y.Category.Name));

            CreateMap<ApplicationUser, RegisterDto>();
            CreateMap<RegisterDto, ApplicationUser>();

            CreateMap<ApplicationUser, BasicUserDto>();
            CreateMap<BasicUserDto, ApplicationUser>();

            CreateMap<ApplicationUser, UserProfileDto>();
            CreateMap<UserProfileDto, ApplicationUser>();

            CreateMap<ApplicationUser, LoginDto>();
            CreateMap<LoginDto, ApplicationUser>();

            CreateMap<CommentDto, Comment>();
            CreateMap<Comment, CommentDto>();

            CreateMap<NewCommentDto, Comment>();
            CreateMap<Comment, NewCommentDto>();
        }
    }
}
