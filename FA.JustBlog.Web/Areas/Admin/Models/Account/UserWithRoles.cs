using FA.JustBlog.Core.Models;

namespace FA.JustBlog.Web.Areas.Admin.Models.Account
{
    public class UserWithRoles
    {
        public User User { get; set; }  // Assuming User is of type IdentityUser or derived from it  
        public List<string> Roles { get; set; }
    }
}
