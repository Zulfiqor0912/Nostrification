using Microsoft.Extensions.FileProviders;
using Nostrification.Application.Extension;
using Nostrification.Infrastructure.Extensions;
using Nostrification.MVC.Extension;
using Nostrification.MVC.Middlewares;

var builder = WebApplication.CreateBuilder(args);
builder.AddPresentation();
builder.Services.AddScoped<ErrorHandlingMiddleware>();

builder.Services.AddApplication();
builder.Services.AddInfrastructure(builder.Configuration);

// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddAuthorization();
var app = builder.Build();

var filesPath = Path.Combine(app.Environment.ContentRootPath, "Files");
// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    //The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseMiddleware<ErrorHandlingMiddleware>();

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseStaticFiles(new StaticFileOptions
{
    FileProvider = new PhysicalFileProvider(filesPath),
    RequestPath = "/Files"
});

app.UseRouting();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
