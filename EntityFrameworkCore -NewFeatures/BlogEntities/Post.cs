using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFrameworkCore__NewFeatures.BlogEntities
{
    public class Post
    {
        public int PostId { get; set; }
        public int BlogId { get; set; }
        public Blog Blog { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
    }
}
