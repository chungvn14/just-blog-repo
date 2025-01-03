using FA.JustBlog.Core.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Core.Configurations
{
    public class PostTagMapConfiguration : IEntityTypeConfiguration<PostTagMap>
    {
        public void Configure(EntityTypeBuilder<PostTagMap> builder)
        {
            // Cấu hình khóa chính cho PostTagMap (khóa chính là sự kết hợp của PostId và TagId)
            builder.HasKey(pt => new { pt.PostId, pt.TagId });

            // Cấu hình quan hệ với Post
            builder.HasOne(pt => pt.Post)
                   .WithMany(p => p.PostTagMaps)
                   .HasForeignKey(pt => pt.PostId);

            // Cấu hình quan hệ với Tag
            builder.HasOne(pt => pt.Tag)
                   .WithMany(t => t.PostTagMaps)
                   .HasForeignKey(pt => pt.TagId);
        }
    }
}
