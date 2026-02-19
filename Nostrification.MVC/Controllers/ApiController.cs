using MediatR;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Mvc;
using Nostrification.Application.Country.Queries.GetDistrictes;
using Nostrification.Application.Country.Queries.GetCountries;
using Nostrification.Application.Region.Queries.GetAllRegions;
using Nostrification.Application.Roles.Query;
using Nostrification.Domain.Repositories;
using System.ComponentModel.Design;
using Nostrification.Application.StudyStep.Queries;
using Nostrification.Application.StudyTypes.Queries;
using Nostrification.Application.MyGov.Commands.DownloadRepo;
using Nostrification.Application.MyGov.Commands.JsonString;

namespace Nostrification.MVC.Controllers;

[Microsoft.AspNetCore.Mvc.Route("[controller]")]
[ApiController]
public class ApiController(
    IOtherRepository otherRepository,
    IMyGovRepository myGovRepository,
    IClaimRepository claimRepository,
    IUserRepository userRepository,
    IMediator mediator) : BaseController
{
    [HttpGet("roles")]
    public async Task<IActionResult> GetRoles()
        => Ok((await mediator.Send(new GetAllRolesQuery())).Select(s => new { s.Id, s.Name }));

    [HttpGet("regions")]
    public async Task<IActionResult> GetRegions()
        => Ok((await mediator.Send(new GetAllRegionsQuery())).Select(s => new { s.Id, s.NameUz }));

    [HttpGet("countries")]
    public async Task<IActionResult> GetCountries()
        => Ok((await mediator.Send(new GetCountriesQuery())).Select(s => new { s.Id, s.NameUz }));

    [HttpGet("districts/{id}")]
    public async Task<IActionResult> GetDistricts(int id)
        => Ok((await mediator.Send(new GetDistrictesQuery(id))).Select(s => new { s.Id, s.NameUz }));

    [HttpGet("study-step")]
    public async Task<IActionResult> GetStudySteps()
        => Ok((await mediator.Send(new GetStudyStepsQuery())).Select(s => new { s.Id, s.Name }));

    [HttpGet("study-type")]
    public async Task<IActionResult> GetStudyTypes()
        => Ok((await mediator.Send(new GetStudyTypesQueries())).Select(s => new { s.Id, s.Name }));

    [HttpGet("download-repo")]
    public async Task<IActionResult> DownloadRepo(int taskId, int version)
    {
        //try
        //{
        //    var claimVersion = "v2";
        //    if (version == 3) claimVersion = "v3";
        //    var (fileBytes, fileName) = await mediator.Send(new DownloadRepoCommand(taskId, claimVersion));
        //    return File(fileBytes, "application/pdf", fileName);
        //}
        //catch (Exception ex) 
        //{
        //    return BadRequest(ex.Message);
        //}

        var claimVersion = "v2";
        if (version == 3) claimVersion = "v3";
        var (fileBytes, fileName) = await mediator.Send(new DownloadRepoCommand(taskId, claimVersion));
        return File(fileBytes, "application/pdf", fileName);
    }

    [HttpGet("push-task")]
    public async Task<IActionResult> PushTask(int taskId)
        => await mediator.Send(new PushTaskCommand(taskId, "v2"));

    [HttpGet("/v3/GetApi/PushTask")]
    public async Task<IActionResult> PushTaskV3(int taskId)
        => await mediator.Send(new PushTaskCommand(taskId, "v3"));
}
