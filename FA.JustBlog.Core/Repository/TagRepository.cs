using FA.JustBlog.Core.Data;
using FA.JustBlog.Core.Infrastructures;
using FA.JustBlog.Core.IRepository;
using FA.JustBlog.Core.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Core.Repository
{
    public class TagRepository : GenericRepository<Tag>, ITagRepository
    {
        private readonly JustBlogContext _context;

        public TagRepository(JustBlogContext context) : base(context)
        {
            _context = context;
        }

        public Tag GetTagByUrlSlug(string urlSlug)
        {
            return _context.Tags.FirstOrDefault(t => t.UrlSlug == urlSlug);
        }

        public IList<Tag> GetTopTags(int topCount)
        {
            var tagsWithPostCount = _context.Tags
                .Join(_context.PostTagMaps, t => t.Id, ptm => ptm.TagId, (t, ptm) => new { Tag = t, PostTagMap = ptm })
                .Join(_context.Posts, t => t.PostTagMap.PostId, p => p.Id, (t, p) => new { Tag = t.Tag, Post = p })
                .Where(tp => tp.Post.Published)  // Only consider published posts
                .GroupBy(tp => new { tp.Tag.Id, tp.Tag.Name })  // Group by Tag Id and Name
                .Select(group => new
                {
                    Tag = group.Key,  // Keep the Tag object in the select
                    PublishedPostCount = group.Count()  // Count the number of posts
                })
                .OrderByDescending(t => t.PublishedPostCount)  // Sort by the count of published posts in descending order
                .Take(topCount)  // Limit to the top 'topCount' tags
                .ToList();

            // Project the result to return a list of Tag objects
            return tagsWithPostCount.Select(x => new Tag { Id = x.Tag.Id,Name= x.Tag.Name, Count = x.PublishedPostCount}).ToList();
        }

        public IList<Tag> GetAllTagsByPost(int postId)
        {
            return _context.PostTagMaps
                           .Where(ptm => ptm.PostId == postId)
                           .Select(ptm => ptm.Tag)
                           .ToList();
        }

    }
}
