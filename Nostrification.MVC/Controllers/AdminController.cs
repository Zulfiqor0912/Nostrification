using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Nostrification.Application.Claims.Dtos;
using Nostrification.Application.Claims.Queries.GetClaimById;
using Nostrification.Application.Claims.Queries.GetClaims;
using Nostrification.Application.Region.Queries.GetAllRegions;
using Nostrification.Application.Roles.Query;
using Nostrification.Application.Users.Command.AddOrUpdateUser;
using Nostrification.Application.Users.Queries.GetAllUsers;
using Nostrification.Application.Users.Queries.GetUserById;
using Nostrification.Application.Users.Queries.GetUserByLogin;
using Nostrification.Domain.Entities;
using Nostrification.MVC.Models.ViewModels;

namespace Nostrification.MVC.Controllers;

[Authorize(Roles = "Admin")]
public class AdminController(
    IMediator mediator) : BaseController
{
    public async Task<ActionResult> Index()
    {
        var claims = await mediator.Send(new GetAllClaimsQuery()) ?? new List<ClaimDto>();
        IndexStatViewModel model = new IndexStatViewModel
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

    public async Task<ActionResult> Claims(int? id)
    {
        var claims = await mediator.Send(new GetAllClaimsQuery());
        if (id == null)
            return View(claims);
        else if (id == 6)
            return View(claims.Where(x => x.CreateDate < DateTime.Now.AddDays(-5) && x.StatusId < 3));
        else 
            return View(claims.Where(x => x.StatusId == id));
    }

    public async Task<ActionResult> ClaimDetails(int id)
    {
        return View(await mediator.Send(new GetClaimByIdQuery(id)));
    }

    public async Task<IActionResult> Users()
    {
        return View(await mediator.Send(new GetAllUsersQuery()));
    }

    public async Task<IActionResult> UserInfo(int id)
    {
        var user = await mediator.Send(new GetUserByIdQuery(id));
        if (id != 0 || user != null) return RedirectToAction("Users");

        var regions = await mediator.Send(new GetAllRegionsQuery());
        var roles = await mediator.Send(new GetAllRolesQuery());

        ViewBag.Regions = new SelectList(regions, "Id", "NameUz", user.RegionId);
        ViewBag.Roles = new SelectList(roles, "Id", "RoleName", user.RoleId);

        return View(user);
    }

    [HttpPost]
    public async Task<IActionResult> UserInfo(UserInfoViewModel viewModel)
    {
        var command = new AddOrUpdateUserCommand(
            viewModel.Id,
            viewModel.Login,
            viewModel.Fullname,
            viewModel.PhoneNumber,
            viewModel.RegionId,
            viewModel.RoleId);

        await mediator.Send(command);
        return RedirectToAction(nameof(User));
    }

    public async Task<IActionResult> Profile()
    {
        var username = User.Identity?.Name;
        var userDto = await mediator.Send(new GetUserByLoginQuery(username));
        return View(userDto);
    }

}
