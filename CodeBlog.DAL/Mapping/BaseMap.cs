using CodeBlog.CORE.Model;
using System;
using System.Collections.Generic;
using System.Data.Entity.ModelConfiguration;
using System.Text;

namespace CodeBlog.DataAccess.Mapping
{
    public class BaseMap<T> : EntityTypeConfiguration<T>
         where T : BaseEntity
    {
        public BaseMap()
        {
            Property(x => x.Created).HasColumnType("datetime2");
            Property(x => x.Updated).HasColumnType("datetime2");
            HasKey(x => x.Id);
        }
    }
}
