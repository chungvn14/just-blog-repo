using FA.JustBlog.Core.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FA.JustBlog.Web.Areas.Admin.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<User> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(UserManager<User> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }


        public async Task<IActionResult> Index()
        {
            var users = _userManager.Users.ToList();
            return View(users);
        }
        [HttpPost]
        public async Task<IActionResult> CreateUser(string userName, string password)
        {
            var user = new User { UserName = userName };
            var result = await _userManager.CreateAsync(user, password);

            if (result.Succeeded)
            {
                // Có thể phân quyền hoặc thực hiện thêm các bước khác sau khi tạo thành công.
                return Ok("User created successfully.");
            }

            return BadRequest(result.Errors);
        }
        [HttpGet]
        public async Task<IActionResult> GetUser(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                return Ok(user);
            }

            return NotFound("User not found");
        }
        [HttpPost]
        public async Task<IActionResult> UpdateUser(string userId, string newUserName)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                user.UserName = newUserName;
                var result = await _userManager.UpdateAsync(user);

                if (result.Succeeded)
                {
                    return Ok("User updated successfully.");
                }

                return BadRequest(result.Errors);
            }

            return NotFound("User not found");
        }
        [HttpPost]
        public async Task<IActionResult> DeleteUser(string userId)
        {
            var user = await _userManager.FindByIdAsync(userId);
            if (user != null)
            {
                var result = await _userManager.DeleteAsync(user);

                if (result.Succeeded)
                {
                    return Ok("User deleted successfully.");
                }

                return BadRequest(result.Errors);
            }

            return NotFound("User not found");
        }
        [HttpPost]
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
        public async Task<IActionResult> GetUsersAndRoles()
        {
            var users = _userManager.Users.ToList();
            var roles = await _roleManager.Roles.ToListAsync();

            return Ok(new { Users = users, Roles = roles });
        }
        public async Task<IActionResult> CreateRole(string roleName)
        {
            var roleExist = await _roleManager.RoleExistsAsync(roleName);
            if (!roleExist)
            {
                var result = await _roleManager.CreateAsync(new IdentityRole(roleName));
                if (result.Succeeded)
                {
                    return Ok("Role created successfully");
                }
                return BadRequest(result.Errors);
            }

            return BadRequest("Role already exists");
        }

        // Xóa role
        public async Task<IActionResult> DeleteRole(string roleName)
        {
            var role = await _roleManager.FindByNameAsync(roleName);
            if (role != null)
            {
                var result = await _roleManager.DeleteAsync(role);
                if (result.Succeeded)
                {
                    return Ok("Role deleted successfully");
                }
                return BadRequest(result.Errors);
            }
            return NotFound("Role not found");
        }
    }
}
