using EntityFrameworkCore__NewFeatures.BlogEntities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System.Linq;

namespace EntityFrameworkCore__NewFeatures
{
    public class BlogDbContext : DbContext
    {

        private static ILoggerFactory dbLoggerCategory =
              LoggerFactory.Create(builder =>
              {
                  builder.AddFilter((category, level) => category == DbLoggerCategory.Database.Command.Name && level == LogLevel.Information).AddConsole();

              });


        //public static readonly ILoggerFactory MyLoggerFactory
        //= LoggerFactory.Create(builder =>
        //{
        //    builder
        //        .AddFilter((category, level) =>
        //            category == DbLoggerCategory.Database.Command.Name
        //            && level == LogLevel.Information)
        //        .AddConsole();
        //});

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.; Database=BlogDb; User Id=sa; Password=Asd123456.");
            optionsBuilder.UseLoggerFactory(dbLoggerCategory);
            base.OnConfiguring(optionsBuilder);
        }

        public DbSet<Blog> Blogs { get; set; }
        public DbSet<Post> Posts { get; set; }
        public DbSet<BlogPostCount> BlogPostCounts { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            modelBuilder.Entity<BlogPostCount>(p =>
            {
                p.HasNoKey();
                p.ToQuery(() => Posts.GroupBy(p => p.Blog.Name).Select(p => new BlogPostCount { BlogName = p.Key, PostCount = p.Count() }));
                //p.Property(p => p.BlogName).HasColumnName("Name");
            });
            modelBuilder.Entity<Blog>().HasData(new Blog() { BlogId = 1, Name = "First Blog" });
            modelBuilder.Entity<Blog>().HasData(new Blog() { BlogId = 2, Name = "Second Blog" });
            modelBuilder.Entity<Post>().HasData(new Post() { PostId = 1, BlogId = 1, Title = "First Post Title", Content = "First Post Content" });
            modelBuilder.Entity<Post>().HasData(new Post() { PostId = 2, BlogId = 1, Title = "Second Post Title", Content = "Second Post Content" });
            modelBuilder.Entity<Post>().HasData(new Post() { PostId = 3, BlogId = 2, Title = "Third Post Title", Content = "Third Post Content" });
            modelBuilder.Entity<Post>().HasData(new Post() { PostId = 4, BlogId = 2, Title = "Fourth Post Title", Content = "Fourth Post Content" });
            modelBuilder.Entity<Post>().HasData(new Post() { PostId = 5, BlogId = 2, Title = "Fiveth Post Title", Content = "Fiveth Post Content" });
            base.OnModelCreating(modelBuilder);
        }
    }
}
