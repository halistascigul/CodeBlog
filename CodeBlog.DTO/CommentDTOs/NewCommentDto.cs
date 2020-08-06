using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBlog.DTO.CommentDTOs
{
   public class NewCommentDto
    {
        public string Content { get; set; }
        public int BlogId { get; set; }
        public int OwnerId { get; set; }
    }
}
