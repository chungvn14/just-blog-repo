using FA.JustBlog.Core.Infrastructures;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FA.JustBlog.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class CommentController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;

        public CommentController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        // GET: Admin/Comment
        public IActionResult Index()
        {
            var comment = _unitOfWork.Comments.GetAllCommentsWithPosts();
            return View(comment);
        }


        // GET: Admin/Comment/Delete/5
        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            // Fetch the comment by its ID (not a list)
            var comment = _unitOfWork.Comments.Find(id.Value);
            if (comment == null)
            {
                return NotFound();
            }

            return View(comment); // Pass the single comment to the view
        }


        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var comment = _unitOfWork.Comments.Find(id); // No async, find comment synchronously

            if (comment != null)
            {
                _unitOfWork.Comments.Delete(comment); // Delete comment synchronously
                _unitOfWork.SaveChanges(); // Save changes synchronously
            }

            return RedirectToAction(nameof(Index)); // Return to index
        }


    }
}
