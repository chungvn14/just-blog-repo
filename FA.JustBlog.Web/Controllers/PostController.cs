using FA.JustBlog.Core.Infrastructures;
using FA.JustBlog.Core.Models;
using FA.JustBlog.Web.Models;
using Microsoft.AspNetCore.Mvc;

namespace FA.JustBlog.Web.Controllers
{
    public class PostController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;
        
        public PostController(IUnitOfWork unitOfWork) : base(unitOfWork) 
        {
            _unitOfWork = unitOfWork;
        }

        // GET: Post
        public IActionResult Index()
        {
            var posts = _unitOfWork.Posts.GetPublisedPosts();
            return View(posts);
        }

        // GET: Post/Details/5
        public IActionResult Details(int year, int month, string title)
        {
            var post = _unitOfWork.Posts.FindPost(year, month, title);
            if (post == null)
            {
                return NotFound();
            }

            // Get related tags for this post
            var tags = _unitOfWork.Tags.GetAllTagsByPost(post.Id); // Assuming this method exists
            ViewData["RelatedTags"] = tags;

            ViewData["HidePopularTags"] = true;

            return View(post);
        }


        public IActionResult ListPosts()
        {
            // Fetch the latest 5 posts and the top 5 most viewed posts
            IList<Post> latestPosts = _unitOfWork.Posts.GetLatestPost(5);
            IList<Post> mostViewedPosts = _unitOfWork.Posts.GetMostViewedPost(5);

            // Create a view model to hold both lists
            var viewModel = new PostListViewModel
            {
                LatestPosts = latestPosts,
                MostViewedPosts = mostViewedPosts
            };

            // Return the Index view and pass the view model
            return PartialView("_PartialListPosts", viewModel);
        }
        public IActionResult ListPostsByTag(string tag)
        {
            // Lấy danh sách các bài viết theo tag
            var posts = _unitOfWork.Posts.GetPostsByTag(tag);

            // Trả về View cùng với danh sách bài viết
            return View(posts);
        }

        public IActionResult ListPostsByCategory(string category)
        {
            // Lấy các bài viết theo category
            var posts = _unitOfWork.Posts.GetPostsByCategory(category);

            // Truyền bài viết vào view
            return View(posts);
        }
    }


}
