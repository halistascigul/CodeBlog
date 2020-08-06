using CodeBlog.DTO.UserDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBlog.DTO.CommentDTOs
{
    public class CommentDto
    {
        public string Content { get; set; }
        public int Likes { get; set; }
        public DateTime Created { get; set; }
        public BasicUserDto Owner { get; set; }
    }
}
