using System.ComponentModel.DataAnnotations;

namespace FA.JustBlog.Web.Areas.Admin.Models.Account
{
    public class CreateUserViewModel
    {
        [Required]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        public List<RoleViewModel> Roles { get; set; } = new List<RoleViewModel>();
    }
}
