using CodeBlog.CORE.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeBlog.DOMAIN.Entities
{
    public class Module : BaseEntity
    {
        public string Name { get; set; }
        public List<Role> Roles { get; set; }
    }
}
