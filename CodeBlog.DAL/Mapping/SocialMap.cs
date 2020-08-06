using CodeBlog.DOMAIN.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace CodeBlog.DataAccess.Mapping
{
    public class SocialMap : BaseMap<Social>
    {
        public SocialMap()
        {
            ToTable("Socials");

            Property(x => x.Url).HasMaxLength(150).IsRequired();
        }
    }
}
