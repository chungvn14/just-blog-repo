using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FA.JustBlog.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "BlogOwner")]
    public class HomeController : Controller
    {
        public IActionResult AdminHome()
        {
            return View();
        }
    }
}
