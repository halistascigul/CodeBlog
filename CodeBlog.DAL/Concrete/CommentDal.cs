﻿using CodeBlog.CORE.Data.EF;
using CodeBlog.DAL.Abstract;
using CodeBlog.DataAccess.Context;
using CodeBlog.DOMAIN.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CodeBlog.DAL.Concrete
{
    public class CommentDal:Repository<CodeBlogDbContext,Comment>,ICommentDal
    {
        public CommentDal(CodeBlogDbContext context) : base(context)
        {

        }
    }
}
