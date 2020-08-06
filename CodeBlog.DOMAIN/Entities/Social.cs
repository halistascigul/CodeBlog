using CodeBlog.CORE.Model;
using CodeBlog.DOMAIN.Constants;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeBlog.DOMAIN.Entities
{
    public class Social : BaseEntity
    {
        public SocialType Type { get; set; }
        public string Url { get; set; }
        public int OwnerId { get; set; }
        public ApplicationUser Owner { get; set; }
    }
}
