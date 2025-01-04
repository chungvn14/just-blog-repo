using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FA.JustBlog.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RoleController : Controller
    {
        private readonly RoleManager<IdentityRole> _roleManager;

        public RoleController(RoleManager<IdentityRole> roleManager)
        {
            _roleManager = roleManager;
        }

        // List all roles
        [HttpGet]
        [Authorize(Roles = "Contributor, BlogOwner")]
        public IActionResult Index()
        {
            var roles = _roleManager.Roles;
            return View(roles);
        }

        // Create Role - GET
        [HttpGet]
        [Authorize(Roles = "BlogOwner")]
        public IActionResult Create()
        {
            return View();
        }

        // Create Role - POST
        [HttpPost]
        [Authorize(Roles = "BlogOwner")]
        public async Task<IActionResult> Create(string roleName)
        {
            if (!string.IsNullOrWhiteSpace(roleName))
            {
                var result = await _roleManager.CreateAsync(new IdentityRole(roleName));
                if (result.Succeeded)
                {
                    return RedirectToAction("Index");
                }

                foreach (var error in result.Errors)
                {
                    ModelState.AddModelError(string.Empty, error.Description);
                }
            }

            return View();
        }

        // Edit Role - GET
        [HttpGet]
        [Authorize(Roles = "BlogOwner")]
        public async Task<IActionResult> Edit(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            if (role == null)
            {
                return NotFound();
            }

            return View(role);
        }

        // Edit Role - POST
        [HttpPost]
        [Authorize(Roles = "BlogOwner")]
        public async Task<IActionResult> Edit(string id, string roleName)
        {
            var role = await _roleManager.FindByIdAsync(id);
            if (role == null)
            {
                return NotFound();
            }

            role.Name = roleName;

            var result = await _roleManager.UpdateAsync(role);
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            return View(role);
        }

        // Delete Role - POST
        [HttpPost]
        [Authorize(Roles = "BlogOwner")]
        public async Task<IActionResult> Delete(string id)
        {
            var role = await _roleManager.FindByIdAsync(id);
            if (role == null)
            {
                return NotFound();
            }

            var result = await _roleManager.DeleteAsync(role);
            if (result.Succeeded)
            {
                return RedirectToAction("Index");
            }

            foreach (var error in result.Errors)
            {
                ModelState.AddModelError(string.Empty, error.Description);
            }

            return RedirectToAction("Index");
        }
    }
}
