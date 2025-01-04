using FA.JustBlog.Core.Models;
using FA.JustBlog.Web.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace FA.JustBlog.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<User> signInManager;
        private readonly UserManager<User> userManager;

        public AccountController(SignInManager<User> signInManager, UserManager<User> userManager)
        {
            this.signInManager = signInManager;
            this.userManager = userManager;
        }

        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Tìm kiếm người dùng theo Email trước, nếu không tìm thấy thì kiểm tra theo Username  
                var user = await userManager.FindByEmailAsync(model.Email);
                         

                // Nếu không tìm thấy người dùng  
                if (user != null)
                {
                    // Sử dụng PasswordSignInAsync để xác thực  
                    var result = await signInManager.PasswordSignInAsync(user, model.Password, model.RememberMe, lockoutOnFailure: false);

                    if (result.Succeeded)
                    {
                        return RedirectToAction("Index", "Home"); // Chuyển hướng nếu đăng nhập thành công  
                    }
                    else if (result.IsLockedOut)
                    {
                        ModelState.AddModelError(string.Empty, "Tài khoản đã bị khóa.");
                    }
                    else
                    {
                        ModelState.AddModelError(string.Empty, "Email or password is incorrect.");
                    }
                }
                else
                {
                    // Thông báo nếu không tìm thấy người dùng (trường hợp cả email và username không tồn tại)  
                    ModelState.AddModelError(string.Empty, "Email or password is incorrect.");
                }
            }

            return View(model); // Trả về view nếu Model không hợp lệ hoặc có lỗi khi đăng nhập  
        }

        public IActionResult Register()
        {
            return View();
        }

      
        [HttpPost]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                // Tạo một đối tượng User mới  
                User user = new User
                {
                    FullName = model.Name,
                    Email = model.Email,
                    UserName = model.Email,
                };

                // Tạo người dùng trong hệ thống  
                var result = await userManager.CreateAsync(user, model.Password);

                if (result.Succeeded)
                {
                    // Gán vai trò "User" cho tài khoản vừa tạo  
                    await userManager.AddToRoleAsync(user, "User");

                    // Chuyển hướng đến trang đăng nhập nếu thành công  
                    return RedirectToAction("Login", "Account");
                }
                else
                {
                    // Nếu tạo người dùng không thành công, thêm lỗi vào ModelState  
                    foreach (var error in result.Errors)
                    {
                        ModelState.AddModelError("", error.Description);
                    }

                    return View(model); // Trả về view với mô hình khi xảy ra lỗi  
                }
            }
            return View(model); // Trả về view nếu Model không hợp lệ  
        }

        public IActionResult VerifyEmail()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> VerifyEmail(VerifyEmailViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByEmailAsync(model.Email);

                if (user == null)
                {
                    ModelState.AddModelError("", "Something is wrong!");
                    return View(model);
                }
                else
                {
                    return RedirectToAction("ChangePassword", "Account", new { username = user.UserName });
                }
            }
            return View(model);
        }

        public IActionResult ChangePassword(string username)
        {
            if (string.IsNullOrEmpty(username))
            {
                return RedirectToAction("VerifyEmail", "Account");
            }
            return View(new ChangePasswordViewModel { Email = username });
        }

        [HttpPost]
        public async Task<IActionResult> ChangePassword(ChangePasswordViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await userManager.FindByNameAsync(model.Email);
                if (user != null)
                {
                    var result = await userManager.RemovePasswordAsync(user);
                    if (result.Succeeded)
                    {
                        result = await userManager.AddPasswordAsync(user, model.NewPassword);
                        return RedirectToAction("Login", "Account");
                    }
                    else
                    {

                        foreach (var error in result.Errors)
                        {
                            ModelState.AddModelError("", error.Description);
                        }

                        return View(model);
                    }
                }
                else
                {
                    ModelState.AddModelError("", "Email not found!");
                    return View(model);
                }
            }
            else
            {
                ModelState.AddModelError("", "Something went wrong. try again.");
                return View(model);
            }
        }

        public async Task<IActionResult> Logout()
        {
            await signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        public IActionResult AccessDenied()
        {
            return View();
        }
    }
}
