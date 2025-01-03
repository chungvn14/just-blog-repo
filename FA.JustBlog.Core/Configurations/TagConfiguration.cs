using FA.JustBlog.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Core.Configurations
{
    public class TagConfiguration : IEntityTypeConfiguration<Tag>
    {
        public void Configure(Microsoft.EntityFrameworkCore.Metadata.Builders.EntityTypeBuilder<Tag> builder)
        {
            builder.Property(t => t.Name)
                  .HasMaxLength(255)
                  .IsRequired();

            builder.Property(t => t.UrlSlug)
                   .HasMaxLength(255)
                   .IsRequired();

            builder.Property(t => t.Description)
                   .HasMaxLength(500);

            builder.Property(t => t.Count)
                   .HasDefaultValue(0); // Mặc định Count là 0

            // Cấu hình quan hệ với PostTagMap
            builder.HasMany(t => t.PostTagMaps)
                   .WithOne(pt => pt.Tag)
                   .HasForeignKey(pt => pt.TagId);
        }
    }
}
