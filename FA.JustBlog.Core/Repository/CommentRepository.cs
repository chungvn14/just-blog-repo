using FA.JustBlog.Core.Data;
using FA.JustBlog.Core.Infrastructures;
using FA.JustBlog.Core.IRepository;
using FA.JustBlog.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FA.JustBlog.Core.Repository
{
    public class CommentRepository : GenericRepository<Comment>, ICommentRepository
    {
        private readonly JustBlogContext _context;

        public CommentRepository(JustBlogContext context) : base(context)
        {
        }

        public void AddComment(int postId, string commentName, string commentEmail, string commentTitle, string commentBody)
        {
            var comment = new Comment
            {
                PostId = postId,
                Name = commentName,
                Email = commentEmail,
                CommentHeader = commentTitle,
                CommentText = commentBody,
                CommentTime = DateTime.Now
            };

            _context.Comments.Add(comment);
            _context.SaveChanges();
        }

        public IList<Comment> GetCommentsForPost(int postId)
        {
            return _context.Comments
                           .Where(c => c.PostId == postId)
                           .OrderBy(c => c.CommentTime) 
                           .ToList();
        }

        public IList<Comment> GetCommentsForPost(Post post)
        {
            return _context.Comments
                           .Where(c => c.PostId == post.Id)
                           .OrderBy(c => c.CommentTime) 
                           .ToList();
        }
    }
}
