using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Nostrification.Application.Claims.Commands.AddOrUpdateClaim;
using Nostrification.Application.Claims.Dtos;
using Nostrification.Application.Claims.Queries.GetClaimById;
using Nostrification.Application.Claims.Queries.GetClaims;
using Nostrification.Application.Logs.Command.AddOrUpdate;
using Nostrification.Application.MyGov.Commands.SendCertificateStatus;
using Nostrification.Application.MyGov.Commands.SendStatusAccept;
using Nostrification.Application.MyGov.Commands.SendStatusReject;
using Nostrification.Application.MyGov.Queries.SendStatus;
using Nostrification.Application.Users.Command.AddOrUpdateUser;
using Nostrification.Application.Users.Queries.GetUserByLogin;
using Nostrification.MVC.Models.ViewModels;

namespace Nostrification.MVC.Controllers;

[Authorize(Roles = "Hudud XTB")]
public class XTBController(IMediator mediator, IWebHostEnvironment environment) : BaseController
{
    public async Task<IActionResult> Index()
    {
        var userClaim = User.Identity;
        var user = await mediator.Send(new GetUserByLoginQuery(userClaim.Name));
        var claims = await mediator.Send(new GetAllClaimsQuery());

        var model = new IndexStatViewModel
        {
            Total = claims.Where(x => x.RegionId == user.RegionId).Count(), 
            Open = claims.Where(x => x.StatusId == 2 && x.RegionId == user.RegionId).Count(),
            Accept = claims.Where(x => x.StatusId == 3 && x.RegionId == user.RegionId).Count(),
            Reject = claims.Where(x => x.StatusId == 4 && x.RegionId == user.RegionId).Count(),
            Anullirovanniy = claims.Where(x => x.StatusId == 5 && x.RegionId == user.RegionId).Count(),
            New = claims.Where(x => x.StatusId == 1 && x.RegionId == user.RegionId).Count(),
            Overdue = claims.Where(x => x.CreateDate < DateTime.Now.AddDays(-5) && x.StatusId < 3).Count(),
            Self = claims.Where(x => x.ClaimerTypeId == 4 && x.RegionId == user.RegionId).Count(),
            Parents = claims.Where(x => x.ClaimerTypeId == 1 && x.RegionId == user.RegionId).Count(),
            Notarial = claims.Where(x => x.ClaimerTypeId == 3 && x.RegionId == user.RegionId).Count(),
            Vasiy = claims.Where(x => x.ClaimerTypeId == 2 && x.RegionId == user.RegionId).Count()
        };

        return View(model);
    }

    public async Task<IActionResult> Claims(int? id)
    {
        var username = User.Identity?.Name;
        var user = await mediator.Send(new GetUserByLoginQuery(username!));
        var claims = await mediator.Send(new GetAllClaimsQuery());
        if (id is null)
            return View(claims.Where(x => x.RegionId == user.RegionId));
        else if (id == 6)
            return View(claims.Where(x => x.RegionId == user.RegionId && x.CreateDate < DateTime.Now.AddDays(-5) && x.StatusId < 3));
        else
            return View(claims.Where(x => x.RegionId == user.RegionId && x.StatusId == id));
    }

    public async Task<IActionResult> ClaimDetails(int id)
    {
        var username = User?.Identity?.Name;
        var user = await mediator.Send(new GetUserByLoginQuery(username));
        var claim = await mediator.Send(new GetClaimByIdQuery(id));

        if (id == 0 || claim is null || claim.RegionId != user.RegionId) return RedirectToAction("Claims");

        if (claim.StatusId == 1)
        {
            var version = (claim.Version.HasValue && claim.Version == 3) ? "v3" : "v2";
            if (await mediator.Send(new SendStatusGetCommand(claim.TaskId, version)))
            {
                claim.StatusId = 2;

                await mediator.Send(new AddOrUpdateLogCommand(
                    claim.TaskId, 
                    user.Login, 
                    "Ko'rib chiqilmoqda", 
                    DateTime.Now));

                await mediator.Send(new AddOrUpdateUserCommand(
                    claim.Id,
                    user.Login,
                    user.Fullname,
                    user.PhoneNumber,
                    user.RegionId,
                    user.RoleId));
            }
        }

        claim = await mediator.Send(new GetClaimByIdQuery(id));

        return View(claim);
    }

    [HttpPost]
    public async Task<IActionResult> Reject([FromForm] ClaimDto updateClaim, IFormFile answerFile)
    {
        var claim = await mediator.Send(new GetClaimByIdQuery(updateClaim.TaskId));
        if (claim.StatusId is 3 or 4) return  RedirectToAction("Claims");

        claim.rejection_reason = updateClaim.rejection_reason;
        claim.name_head_education = updateClaim.name_head_education;
        if (answerFile.Length > 0)
        {
            var uploadFile = Path.Combine(environment.ContentRootPath, "Files");
            Directory.CreateDirectory(uploadFile);

            var fileName = $"{claim.TaskId}_{Path.GetFileName(answerFile.FileName)}";
            var filePath = Path.Combine(uploadFile, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create)) await answerFile.CopyToAsync(stream);
            claim.AnswerFile = fileName;
        }

        var username = User?.Identity?.Name;
        var user = await mediator.Send(new GetUserByLoginQuery(username));

        var fullFilePath = Path.Combine(environment.ContentRootPath, "Files", claim.AnswerFile);
        var bytes = await System.IO.File.ReadAllBytesAsync(fullFilePath);
        var fileBase64 = Convert.ToBase64String(bytes);

        var version = (claim.Version.HasValue && claim.Version == 3) ? "v2" : "v3";

        if (await mediator.Send(new SendStatusRejectCommad
        {
            dto = claim,
            fileString = fullFilePath,
            version = version,
        }))
        {

            claim.StatusId = 4;
            claim.AnswerDate = DateTime.Now;
            await mediator.Send(new AddOrUpdateLogCommand(claim.TaskId, user.Login, "Xulosa yuklandi", DateTime.Now));
            await mediator.Send(new AddOrUpdateClaimCommand(claim));
        }

        return RedirectToAction("Claims");
    }

    [HttpPost]
    public async Task<IActionResult> Accept([FromForm] ClaimDto claimDto, IFormFile answerFile)
    {
        var claim = await mediator.Send(new GetClaimByIdQuery(claimDto.TaskId));
        if (claim.StatusId == 3 || claim.StatusId == 0)
            return RedirectToAction("Claims");

        if (answerFile.Length > 0)
        {
            var uploadsFolder = Path.Combine(environment.ContentRootPath, "Files");
            Directory.CreateDirectory(uploadsFolder);

            var fileName = $"{claim.TaskId}_{Path.GetFileName(answerFile.FileName)}";
            var filePath = Path.Combine(uploadsFolder, fileName);

            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                await answerFile.CopyToAsync(stream);
            }

            claim.AnswerFile = fileName;
        }

        var username = User?.Identity?.Name;
        var user = await mediator.Send(new GetUserByLoginQuery(username));

        claim.StatusId = 3;
        claim.refer_registr_numb = GetReferNumber(claim.Id);
        claim.name_institution_gos = claimDto.name_institution_gos;
        claim.graduation_year = claimDto.graduation_year;
        claim.country_educated_gos = claimDto?.country_educated_gos;
        claim.series_doc_diploma_gos = claimDto?.series_doc_diploma_gos;
        claim.doc_number_diploma_gos = claimDto?.doc_number_diploma_gos;
        claim.name_head_education = claimDto?.name_head_education;
        claim.registry_number = claimDto?.registry_number;
        claim.head_organization = user.Region.XtbName;
        claim.AnswerDate = DateTime.Now;

        var fileFullPath = Path.Combine(environment.ContentRootPath, "Files", claim.AnswerFile);
        var bytes = await System.IO.File.ReadAllBytesAsync(fileFullPath);
        var fileBase64 = Convert.ToBase64String(bytes);
        var version = (claim.Version.HasValue && claim.Version == 3) ? "v3" : "v2";

        if (await mediator.Send(new SendStatusAcceptCommand(taskId: claim.TaskId, fileBase64: fileBase64, version: version)))
        {
            await mediator.Send(new AddOrUpdateLogCommand(claim.TaskId, "Xulosa Yuklandi", user.Login, DateTime.Now));

            if (await mediator.Send(new SendCertificateStatusCommand{ dto = claim, Version = version}))
            {
                await mediator.Send(new AddOrUpdateLogCommand(claim.TaskId, user.Login, "Ma'lumotnoma shakllantirildi", DateTime.Now));
                await mediator.Send(new AddOrUpdateClaimCommand(claim));
            }
        }
        return RedirectToAction("Claims");
    }

    private string GetReferNumber(int taskId)
    {
        string num = taskId.ToString();
        while (num.Length < 7)
            num = '0' + num;
        return 'A' + num;
    }

    public async Task<IActionResult> Profile()
    {
        var username = User?.Identity?.Name;
        var user = await mediator.Send(new GetUserByLoginQuery(username));
        return View(user);
    }

}
