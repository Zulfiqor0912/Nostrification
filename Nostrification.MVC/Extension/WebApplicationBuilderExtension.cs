using Microsoft.AspNetCore.Authentication.Cookies;

namespace Nostrification.MVC.Extension;

public static class WebApplicationBuilderExtension
{
    public static void AddPresentation(this WebApplicationBuilder builder)
    {
        builder.Services.AddAuthentication(CookieAuthenticationDefaults.AuthenticationScheme)
            .AddCookie(options =>
            {
                options.AccessDeniedPath = "/Account/AccessDenied";
                options.LogoutPath = "/Account/Logout";
                options.Cookie.Name = ".Nostrification";
            });
    }
}
