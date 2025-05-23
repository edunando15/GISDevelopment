using GISDevelopment.Abstractions;
using GISDevelopment.Extensions;
using GISDevelopment.Models;
using GISDevelopment.Models.DTOs;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddControllersWithViews();
builder.Services.AddModelServices(builder.Configuration);
builder.Services.AddServices();
builder.Services.AddMvcControllers();
builder.Services.AddAPIControllers();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();
app.UseRouting();
app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();