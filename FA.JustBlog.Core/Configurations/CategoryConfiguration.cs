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
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.Property(c => c.Id)
                 .ValueGeneratedOnAdd() // Tự động tăng
                 .IsRequired();

            builder.Property(c => c.Name)
                   .HasMaxLength(255) // Giới hạn độ dài
                   .IsRequired(); // Không cho phép null

            builder.Property(c => c.UrlSlug)
                   .HasMaxLength(255)
                   .IsRequired();

            builder.Property(c => c.Description)
                   .HasMaxLength(1000); // Miêu tả tối đa 1000 ký tự

            // Cấu hình mối quan hệ
            builder.HasMany(c => c.Posts) // Một Category có nhiều Post
                   .WithOne(p => p.Category) // Một Post thuộc về một Category
                   .HasForeignKey(p => p.CategoryId) // Khóa ngoại là CategoryId
                   .OnDelete(DeleteBehavior.Cascade); // Xóa Category sẽ xóa tất cả Posts liên quan
        }
    }
}
