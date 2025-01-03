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
            // Get the top tags based on the 'Count' of associated posts
            var topTags = _context.Tags
                .OrderByDescending(t => t.Count)  // Ordering by the 'Count' field which indicates the number of posts
                .Take(topCount)  // Limit to the top X tags
                .ToList();

            return topTags;
        }
    }
}
