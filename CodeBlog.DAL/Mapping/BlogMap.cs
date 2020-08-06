using CodeBlog.DOMAIN.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeBlog.DataAccess.Mapping
{
    public class BlogMap : BaseMap<Blog>
    {
        public BlogMap()
        {
            ToTable("Blogs");

            Property(x => x.Title).HasMaxLength(150).IsRequired();
            Property(x => x.Description).HasMaxLength(500).IsRequired();
            Property(x => x.PosterPath).IsRequired();

            HasRequired(x => x.Category)
                .WithMany(x => x.Blogs)
                .HasForeignKey(x => x.CategoryId)
                .WillCascadeOnDelete(false);

            HasRequired(x => x.Owner)
                .WithMany(x => x.Blogs)
                .HasForeignKey(x => x.OwnerId)
                .WillCascadeOnDelete(false);

            HasMany(x => x.Comments)
                .WithRequired(x => x.Blog)
                .HasForeignKey(x => x.BlogId)
                .WillCascadeOnDelete(false);
        }
    }
}
