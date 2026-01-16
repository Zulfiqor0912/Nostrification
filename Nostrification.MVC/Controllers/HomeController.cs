using MediatR;
using Microsoft.AspNetCore.Mvc;
using Nostrification.Application.Claims.Commands.AddOrUpdateClaim;
using Nostrification.Application.Claims.Dtos;
using Nostrification.Application.Claims.Queries.GetClaims;
using Nostrification.Domain.Entities;
using Nostrification.MVC.Models;
using Nostrification.MVC.Models.ViewModels;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace Nostrification.MVC.Controllers
{
    public class HomeController(
        IMediator mediator,
        ILogger<HomeController> logger,
        IWebHostEnvironment environment) : Controller
    {

        public async Task<IActionResult> Index()
        {
            var claimsDto = (await mediator.Send(new GetAllClaimsQuery())) ?? new List<ClaimDto>();
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

        [HttpGet]
        public IActionResult CreateClaim()
        { 
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> CreateClaim(
            ClaimDto model,
            IFormFile PassportFileUpload,
            IFormFile File1Upload,
            IFormFile File2Upload,
            IFormFile AppostilFileUpload)
        {
            try
            {
                // TaskId generatsiya qilish (haqiqiy tizimda bu unique bo'lishi kerak)
                var random = new Random();
                model.TaskId = random.Next(100000, 999999);

                // Fayllarni saqlash
                var uploadsFolder = Path.Combine(environment.ContentRootPath, "Files");
                Directory.CreateDirectory(uploadsFolder);

                if (PassportFileUpload != null && PassportFileUpload.Length > 0)
                {
                    var fileName = $"{model.TaskId}_passport_{Path.GetFileName(PassportFileUpload.FileName)}";
                    var filePath = Path.Combine(uploadsFolder, fileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await PassportFileUpload.CopyToAsync(stream);
                    }
                    model.PassportFile = fileName;
                }

                if (File1Upload != null && File1Upload.Length > 0)
                {
                    var fileName = $"{model.TaskId}_file1_{Path.GetFileName(File1Upload.FileName)}";
                    var filePath = Path.Combine(uploadsFolder, fileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await File1Upload.CopyToAsync(stream);
                    }
                    model.File1 = fileName;
                }

                if (File2Upload != null && File2Upload.Length > 0)
                {
                    var fileName = $"{model.TaskId}_file2_{Path.GetFileName(File2Upload.FileName)}";
                    var filePath = Path.Combine(uploadsFolder, fileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await File2Upload.CopyToAsync(stream);
                    }
                    model.File2 = fileName;
                }

                if (AppostilFileUpload != null && AppostilFileUpload.Length > 0)
                {
                    var fileName = $"{model.TaskId}_appostil_{Path.GetFileName(AppostilFileUpload.FileName)}";
                    var filePath = Path.Combine(uploadsFolder, fileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await AppostilFileUpload.CopyToAsync(stream);
                    }
                    model.AppostilFile = fileName;
                }

                // Ariza holatini yangi qilib belgilash
                model.StatusId = 1; // Yangi
                model.CreateDate = DateTime.Now;
                model.Version = 3; // Yangi versiya

                // Arizani saqlash
                await mediator.Send(new AddOrUpdateClaimCommand(model));

                TempData["Success"] = "Ariza muvaffaqiyatli yuborildi!";
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Ariza yuborishda xatolik");
                TempData["Error"] = "Ariza yuborishda xatolik yuz berdi. Iltimos, qayta urinib ko'ring.";
                return View(model);
            }
        }
    }
}
