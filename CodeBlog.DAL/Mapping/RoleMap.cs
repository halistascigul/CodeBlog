using CodeBlog.DOMAIN.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeBlog.DataAccess.Mapping
{
    public class RoleMap : BaseMap<Role>
    {
        public RoleMap()
        {
            ToTable("Roles");
            Property(x => x.Name).HasMaxLength(20).IsRequired();
        }
    }
}
