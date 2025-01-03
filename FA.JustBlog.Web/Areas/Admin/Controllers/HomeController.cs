using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace FA.JustBlog.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    
    public class HomeController : Controller
    {
        [Authorize(Roles = "Contributor, BlogOwner")]
        public IActionResult AdminHome()
        {
            return View();
        }
    }
}
