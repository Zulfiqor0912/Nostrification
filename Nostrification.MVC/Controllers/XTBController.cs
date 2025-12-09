using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Formatters;
using Nostrification.Application.Claims.Queries.GetClaimById;
using Nostrification.Application.Claims.Queries.GetClaims;
using Nostrification.Application.Users.Queries.GetUserByLogin;
using Nostrification.MVC.Models.ViewModels;

namespace Nostrification.MVC.Controllers;

[Authorize(Roles = "Hudud XTB")]
public class XTBController(IMediator mediator) : BaseController
{
    public async Task<IActionResult> Index()
    {
        var userClaim = User.Identity;
        var user = await mediator.Send(new GetUserByLoginQuery(userClaim.Name));
        var claims = await mediator.Send(new GetAllClaimsQuery());

        var model = new IndexStatViewModel
        {
            Total = claims.Count,
            Open = claims.Where(x => x.StatusId == 2).Count(),
            Accept = claims.Where(x => x.StatusId == 3).Count(),
            Reject = claims.Where(x => x.StatusId == 4).Count(),
            Anullirovanniy = claims.Where(x => x.StatusId == 5).Count(),
            New = claims.Where(x => x.StatusId == 1).Count(),
            Overdue = claims.Where(x => x.CreateDate < DateTime.Now.AddDays(-5) && x.StatusId < 3).Count(),
            Self = claims.Where(x => x.ClaimerTypeId == 4).Count(),
            Parents = claims.Where(x => x.ClaimerTypeId == 1).Count(),
            Notarial = claims.Where(x => x.ClaimerTypeId == 3).Count(),
            Vasiy = claims.Where(x => x.ClaimerTypeId == 2).Count()
        };

        return View(model);
    }

    public async Task<IActionResult> Claims(int? id)
    {
        var username = User.Identity?.Name;
        var user = await mediator.Send(new GetUserByLoginQuery(username!));
        var claims = await mediator.Send(new GetAllClaimsQuery());
        if (id == null)
            return View(claims);
        else if (id == 6)
            return View(claims.Where(x => x.CreateDate < DateTime.Now.AddDays(-5) && x.StatusId < 3));
        else
            return View(claims.Where(x => x.StatusId == id));
    }

    public async Task<IActionResult> ClaimDetails(int id)
    {
        var username = User?.Identity?.Name;
        var user = await mediator.Send(new GetUserByLoginQuery(username));
        var claim = await mediator.Send(new GetClaimByIdQuery(id));

        if (id == 0 || claim is null || claim.RegionId != user.RegionId) return RedirectToAction("Claims");

        if (claim.StatusId == 1)
        {

        }

    }
}
