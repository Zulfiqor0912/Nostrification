using System.Diagnostics;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Nostrification.Application.Claims.Dtos;
using Nostrification.Application.Claims.Queries.GetClaims;
using Nostrification.Domain.Entities;
using Nostrification.MVC.Models;

namespace Nostrification.MVC.Controllers
{
    public class HomeController(
        IMediator mediator,
        ILogger<HomeController> logger) : Controller
    {

        public async Task<IActionResult> Index()
        {
            var claimsDto =(await mediator.Send(new GetAllClaimsQuery())) ?? new List<ClaimDto>();
            var totalCount = claimsDto.Count;
            var openCount = claimsDto.Count(x => x.StatusId < 3);
            
            var model = new IndexStatViewModel
            {
                Total = totalCount,
                Open = openCount,
                Close = totalCount - openCount
            };

            return View(model);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
