using CodeBlog.CORE.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeBlog.DOMAIN.Entities
{
    public class Role : BaseEntity
    {
        public string Name { get; set; }
        public List<Module> Modules { get; set; }
        public List<ApplicationUser> Users { get; set; }
    }
}
