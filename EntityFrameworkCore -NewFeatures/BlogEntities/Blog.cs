using System;
using System.Collections.Generic;
using System.Text;

namespace EntityFrameworkCore__NewFeatures.BlogEntities
{
    public class Blog
    {
        public int BlogId { get; set; }
        public string Name { get; set; }

        public ICollection<Post> Posts { get; set; }
    }
}
