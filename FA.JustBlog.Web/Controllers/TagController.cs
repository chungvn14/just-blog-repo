using FA.JustBlog.Core.Infrastructures;
using FA.JustBlog.Core.Models;
using Microsoft.AspNetCore.Mvc;

namespace FA.JustBlog.Web.Controllers
{
    public class TagController : BaseController
    {
        private readonly IUnitOfWork _unitOfWork;

        public TagController(IUnitOfWork unitOfWork) : base(unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        [HttpGet]
        public IActionResult PopularTags()
        {
            var popularTags = _unitOfWork.Tags.GetTopTags(10);

            // Nếu không có tag nào, trả về danh sách rỗng
            if (popularTags == null || !popularTags.Any())
            {
                Console.WriteLine("No popular tags found.");
                return PartialView("_PopularTags", Enumerable.Empty<Tag>());
            }

            return PartialView("_PopularTags", popularTags);
        }

    }
}
