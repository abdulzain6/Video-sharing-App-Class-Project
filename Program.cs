using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;
using test;


var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllersWithViews();

builder.Services.AddDbContext<ContactDBContext>(options =>
    options.UseSqlite(builder.Configuration.GetConnectionString("Con")));
var app = builder.Build();

if (!app.Environment.IsDevelopment()){
    app.UseExceptionHandler("/Home/Error");
}

app.UseStaticFiles();

app.UseRouting();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();


