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
    public class PostRepository : GenericRepository<Post>, IPostRepository
    {
        private readonly JustBlogContext _context;

        public PostRepository(JustBlogContext context) : base(context)
        {
            _context = context;
        }

        public Post FindPost(int year, int month, string urlSlug)
        {
            return _context.Posts
                           .FirstOrDefault(p => p.UrlSlug == urlSlug && p.PostedOn.Year == year && p.PostedOn.Month == month);
        }

        public int CountPostsForCategory(string category)
        {
            return _context.Posts
                           .Where(p => p.Category.Name == category)
                           .Count();
        }

        public int CountPostsForTag(string tag)
        {
            return _context.Posts
                           .Where(p => p.PostTagMaps.Any(ptm => ptm.Tag.Name == tag))
                           .Count();
        }

        public IList<Post> GetLatestPost(int size)
        {
            return _context.Posts.Where(p => p.Published)
                           .OrderByDescending(p => p.PostedOn)
                           .Take(size)
                           .ToList();
        }


        public IList<Post> GetPostsByCategory(string category)
        {
            return _context.Posts
                           .Where(p => p.Category.Name == category && p.Published == true)
                           .ToList();
        }


        public IList<Post> GetPostsByMonth(DateTime monthYear)
        {
            return _context.Posts
                           .Where(p => p.PostedOn.Year == monthYear.Year && p.PostedOn.Month == monthYear.Month)
                           .ToList();
        }

        public IList<Post> GetPostsByTag(string tag)
        {
            return _context.Posts
                           .Where(p => p.PostTagMaps.Any(ptm => ptm.Tag.Name == tag) && p.Published == true)
                           .ToList();
        }



        public IList<Post> GetPublishedPosts()
        {
            return _context.Posts
                           .Where(p => p.Published)
                           .ToList();
        }

        public IList<Post> GetUnpublishedPosts()
        {
            return _context.Posts
                           .Where(p => !p.Published)
                           .ToList();
        }

        public IList<Post> GetPostsByCategoryAndTag(string category, string tag)
        {
            return _context.Posts
                           .Where(p => p.Category.Name == category && p.PostTagMaps.Any(ptm => ptm.Tag.Name == tag))
                           .ToList();
        }

      
       
        public IList<Post> GetMostViewedPost(int size)
        {
            return _context.Posts
                           .Where(p => p.Published)
                           .OrderByDescending(p => p.ViewCount)
                           .Take(size)
                           .ToList();
        }

        public IList<Post> GetHighestPosts(int size)
        {
            return _context.Posts
                           .Where(p => p.Published)
                           .OrderByDescending(p => p.Rate)
                           .Take(size)
                           .ToList();
        }
        public Post GetPostWithCategory(int id)
        {
            return _context.Posts
                           .Include(p => p.Category)
                           .FirstOrDefault(p => p.Id == id);
        }

        public IEnumerable<Post> GetPostsWithCategory()
        {
            return _context.Posts
                .Include(post => post.Category)  // Include the related Category data
                .ToList();  // Materialize the query to get the data
        }

        public IList<Post> GetLatestPost(int pageNumber, int pageSize)
        {
            return _context.Posts.Where(p => p.Published)
                           .OrderByDescending(p => p.PostedOn)
                           .Skip((pageNumber - 1) * pageSize) // Bỏ qua các bài viết của trang trước
                           .Take(pageSize)                  // Lấy bài viết của trang hiện tại
                           .ToList();
        }
        public IEnumerable<Post> GetLatestPosts()
        {
            return _context.Posts.Where(p => p.Published).OrderByDescending(p => p.PostedOn);
        }

        public IEnumerable<Post> GetMostViewedPosts()
        {
            return _context.Posts.Where(p => p.Published).OrderByDescending(p => p.ViewCount);
        }

        public IEnumerable<Post> GetMostInterestingPosts()
        {
            return _context.Posts.OrderByDescending(p => p.RateCount).ThenByDescending(p => p.TotalRate);
        }

        public IEnumerable<Post> GetUnpublisedPosts()
        {
            return _context.Posts
                    .Where(p => !p.Published)
     
                    .ToList();
        }
        public IEnumerable<Post> GetPublisedPosts()
        {
            return _context.Posts
                   .Where(p => p.Published)
                   .ToList();
        }

    }
}
