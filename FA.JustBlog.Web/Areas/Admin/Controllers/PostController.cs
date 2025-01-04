using FA.JustBlog.Core.Infrastructures;
using FA.JustBlog.Core.Models;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Authorization;
using FA.JustBlog.Web.Areas.Admin.Models.Post;


namespace FA.JustBlog.Web.Areas.Admin.Controllers
{
    [Area("Admin")]

    public class PostController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public PostController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: Admin/Post
        [Authorize(Roles = "Contributor, BlogOwner")]
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



        [HttpPost]
        [Authorize(Roles = "BlogOwner")]
        public IActionResult ChangePublishStatus(int id)
        {
            var post = _unitOfWork.Posts.GetPostWithCategory(id);
            if (post == null)
            {
                return NotFound();
            }

            // Toggle the publish status
            post.Published = !post.Published;

            // Update the post in the database
            _unitOfWork.Posts.Update(post);
            _unitOfWork.SaveChanges();

            TempData["SuccessMessage"] = post.Published ? "Post has been published." : "Post has been unpublished.";

            return RedirectToAction("Details", new { id = post.Id });
        }

        // GET: Admin/Post/Details/5
        [Authorize(Roles = "Contributor, BlogOwner")]
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
        [Authorize(Roles = "Contributor, BlogOwner")]
        public IActionResult Create()
        {
            // Lấy danh sách các Category từ cơ sở dữ liệu và truyền vào View
            ViewBag.CategoryId = new SelectList(_unitOfWork.Categories.GetAll(), "Id", "Name");
            var tags = _unitOfWork.Tags.GetAll();
            ViewBag.Tags = new SelectList(tags, "Id", "Name");
            return View();
        }


        // POST: Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Contributor, BlogOwner")]
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
                    Published = false,
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

                    // Cập nhật số lượng bài viết của từng tag
                    foreach (var tagId in model.Tags)
                    {
                        var tag = _unitOfWork.Tags.Find(tagId);
                        if (tag != null)
                        {
                            // Cập nhật lại số lượng bài viết của tag
                            tag.Count = _unitOfWork.PostTagMaps.CountByTagId(tagId);
                            _unitOfWork.Tags.Update(tag);
                        }
                    }

                    _unitOfWork.SaveChanges();  // Lưu các thay đổi liên quan đến tag
                }

                return RedirectToAction(nameof(Index));
            }

            // Trả về View nếu có lỗi trong model
            ViewBag.CategoryId = new SelectList(_unitOfWork.Categories.GetAll(), "Id", "Name", model.CategoryId);
            ViewBag.Tags = new SelectList(_unitOfWork.Tags.GetAll(), "Id", "Name");  // Cung cấp danh sách tag
            return View(model);
        }


        // GET: Edit
        [Authorize(Roles = "Contributor, BlogOwner")]
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
                CategoryId = post.CategoryId,
                Tags = post.PostTagMaps != null && post.PostTagMaps.Any()
             ? post.PostTagMaps.Select(ptm => ptm.TagId).ToList()
             : null // If no tags, assign null instead of an empty list
            };


            ViewBag.CategoryId = new SelectList(_unitOfWork.Categories.GetAll(), "Id", "Name", post.CategoryId);
            ViewBag.Tags = new SelectList(_unitOfWork.Tags.GetAll(), "Id", "Name");
            return View(model);
        }

        // POST: Edit
        [HttpPost]
        [ValidateAntiForgeryToken]
        [Authorize(Roles = "Contributor, BlogOwner")]
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
                post.CategoryId = model.CategoryId;
                post.UrlSlug = model.Title.ToLower().Replace(" ", "-");
                post.Modified = DateTime.Now;
                // Remove the existing tags
                var existingTags = _unitOfWork.PostTagMaps.GetAll().Where(ptm => ptm.PostId == post.Id);
                foreach (var existingTag in existingTags)
                {
                    _unitOfWork.PostTagMaps.Delete(existingTag);
                }
                if (model.Tags == null || model.Tags.Count == 0)
                {
                    ModelState.AddModelError("Tags", "At least one tag must be selected.");
                    ViewBag.Tags = new SelectList(_unitOfWork.Tags.GetAll(), "Id", "Name");
                    return View(model);
                }

                // Add the new tags
                if (model.Tags != null)
                {
                    foreach (var tagId in model.Tags)
                    {
                        var tag = _unitOfWork.Tags.Find(tagId);
                        var postTagMap = new PostTagMap
                        {
                            PostId = post.Id,
                            TagId = tagId
                        };
                        _unitOfWork.PostTagMaps.Add(postTagMap);
                        var postCount = _unitOfWork.PostTagMaps.CountByTagId(tagId);

                        // Update the tag's post count
                        tag.Count = postCount;
                        _unitOfWork.Tags.Update(tag);
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
        [Authorize(Roles = "BlogOwner")]
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
        [Authorize(Roles = "BlogOwner")]
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
