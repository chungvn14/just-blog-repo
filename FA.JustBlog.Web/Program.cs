using FA.JustBlog.Core.Data;
using FA.JustBlog.Core.Infrastructures;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using System.Configuration;
using Microsoft.AspNetCore.Identity;
using FA.JustBlog.Core.Models;
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<JustBlogContext>(options =>
  options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));
builder.Services.AddIdentity<User, IdentityRole>(options =>
{
    options.Password.RequireNonAlphanumeric = false;
    options.Password.RequiredLength = 8;
    options.Password.RequireUppercase = false;
    options.Password.RequireLowercase = false;
    options.User.RequireUniqueEmail = true;
    options.SignIn.RequireConfirmedAccount = false;
    options.SignIn.RequireConfirmedEmail = false;
    options.SignIn.RequireConfirmedPhoneNumber = false;
})
    .AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<JustBlogContext>()
    .AddDefaultTokenProviders();


builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();


app.MapControllerRoute(
        name: "Post",
        pattern: "Post/{year}/{month}/{title}",
        defaults: new { controller = "Post", action = "Details" });

app.MapControllerRoute(
    name: "Category",
    pattern: "Category/{category}",
    defaults: new { controller = "Post", action = "ListPostsByCategory" });

app.MapControllerRoute(
    name: "Tag",
    pattern: "Tag/{tag}",
    defaults: new { controller = "Post", action = "ListPostsByTag" });

app.MapControllerRoute(
    name: "areas",
    pattern: "{area:exists}/{controller=Home}/{action=AdminHome}/{id?}");

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Post}/{action=ListPosts}/{id?}");

/*app.MapRazorPages();*/
using (var scope= app.Services.CreateScope())
{
    var roleManger = scope.ServiceProvider.GetRequiredService<RoleManager<IdentityRole>>();
    var roles = new[] { "BlogOwner", "Contributor", "User" };
    foreach (var role in roles)
    {
        if (!await roleManger.RoleExistsAsync(role))
            await roleManger.CreateAsync(new IdentityRole(role));
    }
}

using (var scope = app.Services.CreateScope())
{
    var userManger = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
    string email = "admin@admin.com";
    string password = "Test1234";
    if (await userManger.FindByEmailAsync(email) == null)
    {
        var user = new User();
        user.UserName = email;
        user.Email = email;
        
        await userManger.CreateAsync(user, password);
        await userManger.AddToRoleAsync(user, "BlogOwner");
    }

}
using (var scope = app.Services.CreateScope())
{
    var userManger = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
    string email = "user@user.com";
    string password = "Test1234";
    if (await userManger.FindByEmailAsync(email) == null)
    {
        var user = new User();
        user.UserName = email;
        user.Email = email;

        await userManger.CreateAsync(user, password);
        await userManger.AddToRoleAsync(user, "User");
    }

}
using (var scope = app.Services.CreateScope())
{
    var userManger = scope.ServiceProvider.GetRequiredService<UserManager<User>>();
    string email = "contributor@contributor.com";
    string password = "Test1234";
    if (await userManger.FindByEmailAsync(email) == null)
    {
        var user = new User();
        user.UserName = email;
        user.Email = email;

        await userManger.CreateAsync(user, password);
        await userManger.AddToRoleAsync(user, "Contributor");
    }

}
app.Run();
