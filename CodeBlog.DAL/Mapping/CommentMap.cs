using CodeBlog.DOMAIN.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeBlog.DataAccess.Mapping
{
   public class CommentMap : BaseMap<Comment>
    {
        public CommentMap()
        {
            ToTable("Comments");

            Property(x => x.Content).HasMaxLength(500).IsRequired();

            HasRequired(x => x.Owner)
                .WithMany(x => x.Comments)
                .HasForeignKey(x => x.OwnerId)
                .WillCascadeOnDelete(false);

            HasRequired(x => x.Blog)
                .WithMany(x => x.Comments)
                .HasForeignKey(x => x.BlogId)
                .WillCascadeOnDelete(false);
        }
    }
}
