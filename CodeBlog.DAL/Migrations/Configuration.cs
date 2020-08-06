namespace CodeBlog.DAL.Migrations
{
    using CodeBlog.DOMAIN.Entities;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<CodeBlog.DataAccess.Context.CodeBlogDbContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(CodeBlog.DataAccess.Context.CodeBlogDbContext context)
        {
            //  This method will be called after migrating to the latest version.

            //  You can use the DbSet<T>.AddOrUpdate() helper extension method 
            //  to avoid creating duplicate seed data.

            context.Categories.AddOrUpdate(x=>x.Name,
                new Category
                {
                    Name = "C#",
                    Description = "C# ile alakalý aklýnýza gelebilecek her þey"
                },
                new Category
                {
                    Name = "HTML",
                    Description = "HTML ile alakalý aklýnýza gelebilecek her þey"
                },
                new Category
                {
                    Name = "CSS",
                    Description = "CSS ile alakalý aklýnýza gelebilecek her þey"
                },
                new Category
                {
                    Name = "JavaScript",
                    Description = "Javascript ile alakalý aklýnýza gelecebilecek her þey"
                });
        }
    }
}
