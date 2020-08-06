using CodeBlog.DTO.BlogDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBlog.DTO.UserDTOs
{
    public class UserProfileDto
    {
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Job { get; set; }
        public string ProfilePicturePath { get; set; }
        public string AboutText { get; set; }
        public List<BlogListDto> Blogs { get; set; }
    }
}
