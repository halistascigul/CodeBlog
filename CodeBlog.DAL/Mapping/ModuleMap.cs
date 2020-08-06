using CodeBlog.DOMAIN.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeBlog.DataAccess.Mapping
{
    public class ModuleMap : BaseMap<Module>
    {
        public ModuleMap()
        {
            ToTable("Modules");
            Property(x => x.Name).IsRequired().HasMaxLength(20);
            HasIndex(x => x.Name).IsUnique();

            HasMany(x => x.Roles)
                .WithMany(x => x.Modules)
                .Map(x=>x.MapLeftKey("ModuleId").MapRightKey("RoleId").ToTable("RolesModules"));
        }
    }
}


