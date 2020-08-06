using CodeBlog.DTO.CommentDTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBlog.DTO.BlogDTOs
{
    public class SingleBlogDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime Created { get; set; }
        public string PosterPath { get; set; }
        public int Likes { get; set; }
        public int Views { get; set; }
        public List<CommentDto> Comments { get; set; }
        public int CategoryId { get; set; }
        public string CategoryName { get; set; }
        public int OwnerId { get; set; }
        public string OwnerName { get; set; }
        public string OwnerPicturePath { get; set; }
        public string OwnerAboutText { get; set; }
    }
}
