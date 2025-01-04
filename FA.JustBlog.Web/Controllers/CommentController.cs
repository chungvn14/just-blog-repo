using FA.JustBlog.Core.Infrastructures;
using FA.JustBlog.Core.Models;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace FA.JustBlog.Web.Controllers
{
    public class CommentController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CommentController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: Post/Comments/{postId}
        public IActionResult GetComments(int postId)
        {
            var comments = _unitOfWork.Comments.GetCommentsForPost(postId); // Get all comments for the post
            return PartialView("_CommentsPartial", comments);
        }
        [HttpPost]
        public IActionResult DeleteComment(int commentId)
        {
            var comment = _unitOfWork.Comments.Find(commentId);
            if (comment == null)
            {
                return NotFound();
            }

            // Kiểm tra nếu comment là của người dùng đang đăng nhập
            if (comment.Name != User.Identity.Name)
            {
                return Forbid(); // Người dùng không có quyền xóa comment này
            }

            _unitOfWork.Comments.Delete(comment);
            _unitOfWork.SaveChanges(); // Lưu thay đổi vào cơ sở dữ liệu

            return Json(new { success = true });
        }



        // POST: Post/AddComment
        [HttpPost]
        public IActionResult AddComment(int postId, string content)
        {
            if (string.IsNullOrWhiteSpace(content))
            {
                return BadRequest("Comment content cannot be empty.");
            }

            // Retrieve email from the user's claims
            var email = User.FindFirst(ClaimTypes.Email)?.Value ?? "Anonymous";

            var comment = new Comment
            {
                PostId = postId,
                CommentText = content,
                CommentTime = DateTime.Now,
                Name = User.Identity.Name ?? "Anonymous",
                Email = email, // Add the user's email
                CommentHeader = "" // Populate this if needed
            };

            try
            {
                _unitOfWork.Comments.Add(comment); // Save the comment to the database
                _unitOfWork.SaveChanges(); // Commit changes

                // Return the new comment to update the UI dynamically
                return PartialView("_CommentPartial", comment);
            }
            catch (Exception ex)
            {
                // Log the exception (optional)
                Console.WriteLine(ex.Message);
                return StatusCode(500, "An error occurred while saving the comment.");
            }
        }
    }
}
