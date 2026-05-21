using Microsoft.EntityFrameworkCore; // 讓系統認得 UseSqlServer()
using WebApplication1.Models;      // 讓系統認得 AppDbContext (假設你存在 Models 資料夾)
using System;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// 註冊 AppDbContext，並讀取 appsettings.json 的連線字串
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddControllersWithViews();
builder.Services.AddRazorPages();

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

// Standard routing
app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.MapRazorPages();

app.Run();