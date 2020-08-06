using CodeBlog.CORE.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeBlog.DOMAIN.Entities
{
    public class Blog : BaseEntity
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public string Content { get; set; }
        public string Url { get; set; }
        public string PosterPath { get; set; }
        public int Likes { get; set; }
        public int Views { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public int OwnerId { get; set; }
        public ApplicationUser Owner { get; set; }
        public List<Comment> Comments { get; set; }
    }
}
