using FA.JustBlog.Core.Configurations;
using FA.JustBlog.Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Core.Data
{
    public class JustBlogContext : IdentityDbContext<User>
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Server=LAPTOP-8CR58S4O;Database=JustBlog;Trusted_Connection=True;TrustServerCertificate=True;").UseLazyLoadingProxies();
            }
            else
            {
                base.OnConfiguring(optionsBuilder);
            }
        }

        public JustBlogContext()
        {
        }

        public JustBlogContext(DbContextOptions<JustBlogContext> options) : base(options)
        {
        }


        public virtual DbSet<Category> Categories { get; set; }
        public virtual DbSet<Tag> Tags { get; set; }
        public virtual DbSet<Post> Posts { get; set; }
        public virtual DbSet<PostTagMap> PostTagMaps { get; set; }
        public virtual DbSet<Comment> Comments { get; set; }
       


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {

            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PostTagMapConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CategoryConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(TagConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(PostConfiguration).Assembly);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(CommentConfiguration).Assembly);
            modelBuilder.Seeding();
        }
    }
}
