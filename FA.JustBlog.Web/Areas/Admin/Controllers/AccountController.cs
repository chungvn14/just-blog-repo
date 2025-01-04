using FA.JustBlog.Core.Models;
using FA.JustBlog.Web.Areas.Admin.Models.Account;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FA.JustBlog.Web.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }
        [Authorize(Roles = "Contributor, BlogOwner")]
        public IActionResult Index()
        {
            var users = _userManager.Users.ToList();
            var userRoles = new List<UserWithRoles>();

            foreach (var user in users)
            {
                var roles = _userManager.GetRolesAsync(user).Result;

                userRoles.Add(new UserWithRoles
                {
                    User = user,
                    Roles = roles.ToList()
                });
            }

            return View(userRoles); // Ensure this matches the view model  
        }
        [Authorize(Roles = "BlogOwner")]
        public IActionResult Create()
        {
            var roles = _roleManager.Roles.Select(r => new RoleViewModel
            {
                RoleName = r.Name,
                IsSelected = false
            }).ToList();

            var model = new CreateUserViewModel
            {
                Roles = roles // Ensure this is not null  
            };

            return View(model);
        }
        [HttpPost]
        [Authorize(Roles = "BlogOwner")]
        public async Task<IActionResult> Create(CreateUserViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            // Debugging: kiểm tra xem model.Roles có đúng không  
            foreach (var role in model.Roles)
            {
                // Kiểm tra dữ liệu  
                Console.WriteLine($"Role: {role.RoleName}, IsSelected: {role.IsSelected}");
            }

            var user = new User { UserName = model.UserName, Email = model.Email };
            var result = await _userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
            {
                var selectedRoles = model.Roles?.Where(r => r.IsSelected).Select(r => r.RoleName).ToList();
                if (selectedRoles != null && selectedRoles.Count > 0)
                {
                    foreach (var role in selectedRoles)
                    {
                        var addToRoleResult = await _userManager.AddToRoleAsync(user, role);
                        if (!addToRoleResult.Succeeded)
                        {
                            // Xử lý lỗi  
                            foreach (var error in addToRoleResult.Errors)
                            {
                                ModelState.AddModelError(string.Empty, error.Description);
                            }
                        }
                    }
                }
                return RedirectToAction(nameof(Index));
            }

            return View(model);
        }
       
        [HttpGet]
        [Route("Admin/Account/Edit/{Id?}")]
        [Authorize(Roles = "BlogOwner")]
        public async Task<IActionResult> Edit(string? Id)
        {
            Console.WriteLine("User ID: " + Id);

            var user = await _userManager.FindByIdAsync(Id);
            if (user == null)
            {
                return NotFound();
            }

            var roles = await _roleManager.Roles.Select(r => r.Name).ToListAsync();
            var userRoles = (await _userManager.GetRolesAsync(user)).ToList();

            var model = new EditUserViewModel
            {
                UserId = user.Id,
                UserName = user.UserName,
                Email = user.Email,
                AllRoles = roles,
                SelectedRoles = userRoles ?? new List<string>() // Ensure SelectedRoles is not null
            };

            return View(model);
        }

        [HttpPost]
        [Authorize(Roles = "BlogOwner")]
        public async Task<IActionResult> Edit(EditUserViewModel model)
        {
            if (!ModelState.IsValid)
            {
                // Reload roles if ModelState fails
                model.AllRoles = await _roleManager.Roles.Select(r => r.Name).ToListAsync();
                model.SelectedRoles ??= new List<string>();
                return View(model);
            }

            var user = await _userManager.FindByIdAsync(model.UserId);
            if (user == null)
            {
                return NotFound("User not found.");
            }

            // Current roles
            var currentRoles = await _userManager.GetRolesAsync(user);

            // Roles to add and remove
            var rolesToAdd = model.SelectedRoles.Except(currentRoles).ToList();
            var rolesToRemove = currentRoles.Except(model.SelectedRoles).ToList();

            // Update roles
            var addResult = await _userManager.AddToRolesAsync(user, rolesToAdd);
            var removeResult = await _userManager.RemoveFromRolesAsync(user, rolesToRemove);

            if (!addResult.Succeeded || !removeResult.Succeeded)
            {
                ModelState.AddModelError("", "Failed to update roles.");
                model.AllRoles = await _roleManager.Roles.Select(r => r.Name).ToListAsync();
                return View(model);
            }

            return RedirectToAction("Index");
        }



        [HttpPost]
        [Authorize(Roles = "BlogOwner")]
        public async Task<IActionResult> DeleteUser(string userId)
        {
            if (string.IsNullOrWhiteSpace(userId))
            {
                TempData["ErrorMessage"] = "User ID is required.";
                return RedirectToAction("Index"); // Thay "Index" thành tên action mà bạn đang sử dụng  
            }

            var user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                TempData["ErrorMessage"] = "User not found.";
                return RedirectToAction("Index");
            }

            var result = await _userManager.DeleteAsync(user);
            if (result.Succeeded)
            {
                TempData["SuccessMessage"] = "User deleted successfully.";
            }
            else
            {
                var errors = string.Join(", ", result.Errors.Select(e => e.Description));
                TempData["ErrorMessage"] = $"Error deleting user: {errors}";
            }

            return RedirectToAction("Index"); // Trở về danh sách người dùng  
        }

        [HttpPost]
        [Authorize(Roles = "BlogOwner")]
        public async Task<IActionResult> AssignRole(string userId, string roleName)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                var result = await _userManager.AddToRoleAsync(user, roleName);
                if (result.Succeeded)
                {
                    return Ok("Role assigned successfully.");
                }

                return BadRequest(result.Errors);
            }

            return NotFound("User not found");
        }
        [HttpGet]
        [Authorize(Roles = "Contributor, BlogOwner")]
        public async Task<IActionResult> GetUsersAndRoles()
        {
            var users = _userManager.Users.ToList();
            var roles = await _roleManager.Roles.ToListAsync();

            return Ok(new { Users = users, Roles = roles });
        }
        

    }
}
