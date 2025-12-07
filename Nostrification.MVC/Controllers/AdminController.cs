using MediatR;
using Microsoft.AspNetCore.Mvc;
using Nostrification.Application.Claims.Dtos;
using Nostrification.Application.Claims.Queries.GetClaimById;
using Nostrification.Application.Claims.Queries.GetClaims;
using Nostrification.Domain.Entities;

namespace Nostrification.MVC.Controllers;

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
}
