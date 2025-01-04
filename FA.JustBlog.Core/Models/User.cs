using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FA.JustBlog.Core.Models
{
    public class User : IdentityUser
    {
        public string? FullName { get; set; }
        public async Task<IList<string>> GetRolesAsync(UserManager<User> userManager)
        {
            return await userManager.GetRolesAsync(this);
        }
    }
   
}
