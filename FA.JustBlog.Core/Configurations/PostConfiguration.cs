using FA.JustBlog.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Core.Configurations
{
    public class PostConfiguration : IEntityTypeConfiguration<Post>
    {
        public void Configure(EntityTypeBuilder<Post> builder)
        {
            builder.Property(p => p.Title)
                   .HasMaxLength(255)
                   .IsRequired();

            builder.Property(p => p.ShortDescription)
                   .HasMaxLength(500);

            builder.Property(p => p.PostContent)
                   .HasColumnType("ntext");

            builder.Property(p => p.UrlSlug)
                   .HasMaxLength(255)
                   .IsRequired();

            builder.Property(p => p.Published)
                   .HasDefaultValue(false);

            builder.Property(p => p.PostedOn)
                   .IsRequired();

            builder.Property(p => p.Modified)
                   .IsRequired();

            // Cấu hình quan hệ với Category
            builder.HasOne(p => p.Category)
                   .WithMany(c => c.Posts)
                   .HasForeignKey(p => p.CategoryId)
                   .OnDelete(DeleteBehavior.Cascade);

            // Cấu hình quan hệ với PostTagMap
            builder.HasMany(p => p.PostTagMaps)
                   .WithOne(pt => pt.Post)
                   .HasForeignKey(pt => pt.PostId);
        }
    }
}
