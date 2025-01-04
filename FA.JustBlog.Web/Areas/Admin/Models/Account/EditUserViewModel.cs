using System.ComponentModel.DataAnnotations;

namespace FA.JustBlog.Web.Areas.Admin.Models.Account
{
    public class EditUserViewModel
    {
       
        public string UserId { get; set; } = string.Empty;

        public string UserName { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public List<string> AllRoles { get; set; } = new List<string>();

        public List<string> SelectedRoles { get; set; } = new List<string>();
    }
}
