using FA.JustBlog.Core.Models;

namespace FA.JustBlog.Web.Models
{
    public class PostListViewModel
    {
        public IList<Post> LatestPosts { get; set; }
        public IList<Post> MostViewedPosts { get; set; }
    }
}
