using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;

namespace EntityFrameworkCore__NewFeatures
{
    class Program
    {
        static void Main(string[] args)
        {

            using BlogDbContext blogDbContext = new BlogDbContext();
            //blogDbContext.Database.EnsureDeleted();
            //blogDbContext.Database.EnsureCreated();

            //        blogDbContext.Database.ExecuteSqlRaw(
            //@"CREATE VIEW View_BlogPostCounts AS 
            //    SELECT b.Name, Count(p.PostId) as PostCount 
            //    FROM Blogs b
            //    JOIN Posts p on p.BlogId = b.BlogId
            //    GROUP BY b.Name");



            var blogPostCount = blogDbContext.BlogPostCounts.TagWith("Get post counts for blogs").ToList();

            foreach (var item in blogPostCount)
            {
                Console.WriteLine($"{item.BlogName} has {item.PostCount} posts");
            }

            Console.ReadKey();



            //blogDbContext.Database.Migrate();

        }
    }
}
