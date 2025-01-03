using FA.JustBlog.Core.Infrastructures;
using FA.JustBlog.Core.Models;
using Microsoft.AspNetCore.Mvc;
using System.Linq;

namespace FA.JustBlog.Web.ViewComponents
{
    public class PopularTagsViewComponent : ViewComponent
    {
        private readonly IUnitOfWork _unitOfWork;

        public PopularTagsViewComponent(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IViewComponentResult Invoke()
        {
            var popularTags = _unitOfWork.Tags.GetTopTags(10); // Lấy 10 tag phổ biến nhất
            return View(popularTags ?? Enumerable.Empty<Tag>());
        }
    }
}
