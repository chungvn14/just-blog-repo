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
    public class CommentConfiguration : IEntityTypeConfiguration<Comment>
    {
        public void Configure(EntityTypeBuilder<Comment> builder)
        {
            builder.Property(c => c.Name)
               .IsRequired()  // Ensure Name is required
               .HasMaxLength(100);  // Max length of 100 characters

            builder.Property(c => c.Email)
                .IsRequired()  // Ensure Email is required
                .HasMaxLength(255);  // Max length of 255 characters

            builder.Property(c => c.CommentHeader)
                .IsRequired()  // Ensure CommentHeader is required
                .HasMaxLength(200);  // Max length of 200 characters

            builder.Property(c => c.CommentText)
                .IsRequired()  // Ensure CommentText is required
                .HasColumnType("text");  // Use "text" type for larger content

            builder.Property(c => c.CommentTime)
                .IsRequired()  // Ensure CommentTime is required
                .HasDefaultValueSql("GETDATE()");  // Default to the current date and time when the comment is created

            // Foreign key relationship with Post
            builder.HasOne(c => c.Post)
                .WithMany(p => p.Comments)  // Assuming a post has many comments
                .HasForeignKey(c => c.PostId)
                .OnDelete(DeleteBehavior.Cascade);  // Delete comments when a post is deleted (optional)

        }
    }
}
