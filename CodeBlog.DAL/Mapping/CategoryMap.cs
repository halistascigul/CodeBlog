using CodeBlog.DOMAIN.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeBlog.DataAccess.Mapping
{
    public class CategoryMap : BaseMap<Category>
    {
        public CategoryMap()
        {
            ToTable("Categories");

            Property(x => x.Name).HasMaxLength(50).IsRequired();
            HasIndex(x => x.Name).IsUnique();
            Property(x => x.Description).HasMaxLength(200);

            HasMany(x => x.Blogs)
                .WithRequired(x => x.Category)
                .HasForeignKey(x => x.CategoryId)
                .WillCascadeOnDelete(false);
        }
    }
}
