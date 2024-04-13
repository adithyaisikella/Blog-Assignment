using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Blog.Models;

    public class BlogDBContext : DbContext
    {
        public BlogDBContext (DbContextOptions<BlogDBContext> options)
            : base(options)
        {
        }

        public DbSet<Blog.Models.Blog> Blog { get; set; } = default!;
    }
