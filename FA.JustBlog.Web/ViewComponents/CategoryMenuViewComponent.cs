using FA.JustBlog.Core.Infrastructures;
using Microsoft.AspNetCore.Mvc;

namespace FA.JustBlog.Web.Components
{
    public class CategoryMenuViewComponent : ViewComponent
    {
        private readonly IUnitOfWork _unitOfWork;

        public CategoryMenuViewComponent(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        public IViewComponentResult Invoke()
        {
            // Lấy danh sách Categories từ UnitOfWork
            var categories = _unitOfWork.Categories.GetAll();
            return View(categories); // Truyền vào View để hiển thị
        }
    }
}
