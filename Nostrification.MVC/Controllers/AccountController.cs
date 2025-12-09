using MediatR;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Nostrification.Application.Users.Queries.GetUserByLogin;
using System.Security.Claims;

namespace Nostrification.MVC.Controllers;

public class AccountController(IMediator mediator) : BaseController
{

    public async Task<IActionResult> DevLogin()
    {
        var login = "XTB";
        var user = await mediator.Send(new GetUserByLoginQuery(login));

        var claims = new List<Claim>
        {
            new Claim(ClaimTypes.Name, user.Login),
            new Claim(ClaimTypes.Role, user.Role.Name)
        };

        var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
        var principal = new ClaimsPrincipal(identity);

        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

        return user.RoleId switch
        {
            1 => RedirectToAction("Index", "Admin"),
            2 => RedirectToAction("Index", "XTB"),
            _ => RedirectToAction("Index", "Home")
        };
    }

    public IActionResult oauth_chk()
    {
        return RedirectToAction("DevLogin", "Account");
    }
}
