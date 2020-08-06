﻿using CodeBlog.CORE.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeBlog.DOMAIN.Entities
{
    public class Comment : BaseEntity
    {
        public string Content { get; set; }
        public int Likes { get; set; }
        public int OwnerId { get; set; }
        public ApplicationUser Owner { get; set; }
        public int BlogId { get; set; }
        public Blog Blog { get; set; }
    }
}
