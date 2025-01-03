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
    public class PostTagMapRepository : GenericRepository<PostTagMap>, IPostTagMapRepository
    {
        private readonly JustBlogContext _context;

        public PostTagMapRepository(JustBlogContext context) : base(context)
        {
            _context = context;
        }
        
        public void AddRange(IEnumerable<PostTagMap> postTagMaps)
        {
            _context.PostTagMaps.AddRange(postTagMaps);
        }
    }
}
