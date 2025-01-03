using FA.JustBlog.Core.Infrastructures;
using FA.JustBlog.Core.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using FA.JustBlog.Web.Areas.Admin.Models;
using Microsoft.AspNetCore.Authorization;


namespace FA.JustBlog.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "BlogOwner")]
    public class PostController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public PostController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: Admin/Post
        public IActionResult Index(string filter)
        {
            // Xử lý bộ lọc
            var filters = new List<SelectListItem>
    {
        new SelectListItem { Value = "", Text = "Select Filter", Selected = string.IsNullOrEmpty(filter) },
        new SelectListItem { Value = "latest", Text = "Latest Posts", Selected = filter == "latest" },
        new SelectListItem { Value = "mostViewed", Text = "Most Viewed Posts", Selected = filter == "mostViewed" },
        new SelectListItem { Value = "mostInteresting", Text = "Most Interesting Posts", Selected = filter == "mostInteresting" },
        new SelectListItem { Value = "published", Text = "Published Posts", Selected = filter == "published" },
        new SelectListItem { Value = "unpublished", Text = "Un-published Posts", Selected = filter == "unpublished" },
        new SelectListItem { Value = "allposts", Text = "All Posts", Selected = filter == "allposts" }
    };

            ViewBag.Filters = filters;

            // Lấy dữ liệu bài viết theo bộ lọc
            IEnumerable<Post> posts = _unitOfWork.Posts.GetPostsWithCategory();

            switch (filter)
            {
                case "latest":
                    posts = _unitOfWork.Posts.GetLatestPosts();
                    break;
                case "mostViewed":
                    posts = _unitOfWork.Posts.GetMostViewedPosts();
                    break;
                case "mostInteresting":
                    posts = _unitOfWork.Posts.GetMostViewedPosts();
                    break;
                case "published":
                    posts = _unitOfWork.Posts.GetPublisedPosts();
                    break;
                case "unpublished":
                    posts = _unitOfWork.Posts.GetUnpublisedPosts();
                    break;
                case "allposts":
                    posts = _unitOfWork.Posts.GetPostsWithCategory();
                    break;
                default:
                    break;
            }

           

            return View(posts);
        }





        // GET: Admin/Post/Details/5
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = _unitOfWork.Posts.GetPostWithCategory(id.Value);
            if (post == null)
            {
                return NotFound();
            }

            return View(post);
        }


        // GET: Create
        public IActionResult Create()
        {
            // Lấy danh sách các Category từ cơ sở dữ liệu và truyền vào View
            ViewBag.CategoryId = new SelectList(_unitOfWork.Categories.GetAll(), "Id", "Name");
            var tags = _unitOfWork.Tags.GetAll();
            ViewBag.Tags = new SelectList(tags, "Id", "Name");
            return View();
        }

        // POST: Create
        // POST: Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(PostCreateModel model)
        {
            if (ModelState.IsValid)
            {
                var post = new Post
                {
                    Title = model.Title,
                    ShortDescription = model.ShortDescription,
                    PostedOn = model.PostedOn,
                    CategoryId = model.CategoryId,
                    Published = model.Published,
                    PostContent = model.PostContent,
                    UrlSlug = model.Title.ToLower().Replace(" ", "-"),
                    Modified = DateTime.Now,
                    ViewCount = 0,
                    RateCount = 0,
                    TotalRate = 0
                };

                // Thêm bài viết mới vào cơ sở dữ liệu
                _unitOfWork.Posts.Add(post);
                _unitOfWork.SaveChanges();  // Đảm bảo lưu bài viết trước để có PostId

                // Xử lý các tags đã chọn
                if (model.Tags != null && model.Tags.Any())
                {
                    var postTags = model.Tags.Select(tagId => new PostTagMap
                    {
                        PostId = post.Id,  // Liên kết bài viết
                        TagId = tagId      // Liên kết với mỗi tag được chọn
                    }).ToList();

                    // Thêm tất cả liên kết vào bảng PostTagMap
                    _unitOfWork.PostTagMaps.AddRange(postTags);
                    _unitOfWork.SaveChanges();
                }

                return RedirectToAction(nameof(Index));
            }

            // Trả về View nếu có lỗi trong model
            ViewBag.CategoryId = new SelectList(_unitOfWork.Categories.GetAll(), "Id", "Name", model.CategoryId);
            ViewBag.Tags = new SelectList(_unitOfWork.Tags.GetAll(), "Id", "Name");  // Cung cấp danh sách tag
            return View(model);
        }

        // GET: Edit
        public IActionResult Edit(int id)
        {
            var post = _unitOfWork.Posts.Find(id);
            var tagIds = _unitOfWork.PostTagMaps.GetAll().Where(p => p.PostId == post.Id);


            if (post == null)
            {
                return NotFound();
            }

            var model = new PostViewModel
            {
                Id = post.Id,
                Title = post.Title,
                ShortDescription = post.ShortDescription,
                PostContent = post.PostContent,
                PostedOn = post.PostedOn,
                Published = post.Published,
                CategoryId = post.CategoryId,
                Tags = post.PostTagMaps.Select(ptm => ptm.TagId).ToList() // Sử dụng ToList() thay vì ToArray()
            };

            ViewBag.CategoryId = new SelectList(_unitOfWork.Categories.GetAll(), "Id", "Name", post.CategoryId);
            ViewBag.Tags = new SelectList(_unitOfWork.Tags.GetAll(), "Id", "Name");
            return View(model);
        }

        // POST: Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, PostViewModel model)
        {
            if (id != model.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                var post = _unitOfWork.Posts.Find(id);
                if (post == null)
                {
                    return NotFound();
                }

                post.Title = model.Title;
                post.ShortDescription = model.ShortDescription;
                post.PostContent = model.PostContent;
                post.PostedOn = model.PostedOn;
                post.Published = model.Published;
                post.CategoryId = model.CategoryId;
                post.UrlSlug = model.Title.ToLower().Replace(" ", "-");
                post.Modified = DateTime.Now;
                // Remove the existing tags
                var existingTags = _unitOfWork.PostTagMaps.GetAll().Where(ptm => ptm.PostId == post.Id);
                foreach (var existingTag in existingTags)
                {
                    _unitOfWork.PostTagMaps.Delete(existingTag);
                }

                // Add the new tags
                if (model.Tags != null)
                {
                    foreach (var tagId in model.Tags)
                    {
                        var postTagMap = new PostTagMap
                        {
                            PostId = post.Id,
                            TagId = tagId
                        };
                        _unitOfWork.PostTagMaps.Add(postTagMap);
                    }
                }
                // Cập nhật bài viết trong cơ sở dữ liệu
                _unitOfWork.Posts.Update(post);

                return RedirectToAction(nameof(Index));
            }

            ViewBag.CategoryId = new SelectList(_unitOfWork.Categories.GetAll(), "Id", "Name", model.CategoryId);
            return View(model);
        }



        // GET: Admin/Post/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var post = _unitOfWork.Posts.GetPostWithCategory(id.Value);
            if (post == null)
            {
                return NotFound();
            }

            return View(post);
        }

        // POST: Admin/Post/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var post = _unitOfWork.Posts.Find(id);  // Thay vì _context.Posts
            if (post != null)
            {
                _unitOfWork.Posts.Delete(post);  // Thay vì _context.Posts.Remove(post)

            }

            return RedirectToAction(nameof(Index));
        }

        private async Task<bool> PostExists(int id)
        {
            return _unitOfWork.Posts.Find(id) != null;  // Thay vì _context.Posts.Any(e => e.Id == id)
        }
    }
}
