using FA.JustBlog.Core.Infrastructures;
using FA.JustBlog.Core.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

public class BaseController : Controller
{
    private readonly IUnitOfWork _unitOfWork;

    public BaseController(IUnitOfWork unitOfWork)
    {
        _unitOfWork = unitOfWork;
    }

    // Override phương thức OnActionExecuting để đảm bảo danh mục được nạp vào mọi controller
    public override void OnActionExecuting(ActionExecutingContext context)
    {
        base.OnActionExecuting(context);

        // Lấy danh sách các Category từ cơ sở dữ liệu
        var categories = _unitOfWork.Categories.GetAll();

        // Kiểm tra nếu danh sách Categories có giá trị hợp lệ
        if (categories != null && categories.Any())
        {
            ViewBag.Categories = categories;
        }
        else
        {
            ViewBag.Categories = new List<Category>(); // Gán danh sách trống nếu không có Category
        }
    }
}
