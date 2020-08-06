using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBlog.DTO.BlogDTOs
{
    public class BlogListDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public DateTime Created { get; set; }
        public int Likes { get; set; }
        public string OwnerName { get; set; }
        public string PosterPath { get; set; }
        public string Description { get; set; }
        public string OwnerJob { get; set; }
        public string Url { get; set; }
    }
}
