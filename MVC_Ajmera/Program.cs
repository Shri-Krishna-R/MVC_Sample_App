using Microsoft.EntityFrameworkCore;
using MVC_Ajmera.Controllers;
using MVC_Ajmera.Models;
using NuGet.Protocol.Core.Types;
using System;
using System.Configuration;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllersWithViews();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
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

builder.Services.AddDbContext<MVC_AjmeraContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("MVC_Ajmera"));
});

builder.Services.AddControllersWithViews();





